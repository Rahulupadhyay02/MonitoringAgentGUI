using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class RdpSessionMonitor
    {
        private const int WTS_CURRENT_SERVER_HANDLE = 0;

        [DllImport("Wtsapi32.dll")]
        private static extern bool WTSEnumerateSessions(
            IntPtr hServer,
            int Reserved,
            int Version,
            out IntPtr ppSessionInfo,
            out int pCount
        );

        [DllImport("Wtsapi32.dll")]
        private static extern void WTSFreeMemory(IntPtr pMemory);

        [DllImport("Wtsapi32.dll", CharSet = CharSet.Auto)]
        private static extern bool WTSQuerySessionInformation(
            IntPtr hServer,
            int sessionId,
            WTSInfoClass wtsInfoClass,
            out IntPtr ppBuffer,
            out int pBytesReturned
        );

        private enum WTSInfoClass
        {
            WTSUserName = 5,
            WTSConnectState = 4,
            WTSLogonTime = 8
        }

        private enum WTS_CONNECTSTATE_CLASS
        {
            Active,
            Connected,
            ConnectQuery,
            Shadow,
            Disconnected,
            Idle,
            Listen,
            Reset,
            Down,
            Init
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public int SessionID;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pWinStationName;
            public WTS_CONNECTSTATE_CLASS State;
        }

        public static List<RdpSessionInfo> GetRdpSessions()
        {
            var sessionList = new List<RdpSessionInfo>();

            try
            {
                IntPtr ppSessionInfo = IntPtr.Zero;
                int sessionCount;

                if (WTSEnumerateSessions(IntPtr.Zero, 0, 1, out ppSessionInfo, out sessionCount))
                {
                    int dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                    IntPtr current = ppSessionInfo;

                    for (int i = 0; i < sessionCount; i++)
                    {
                        var sessionInfo = (WTS_SESSION_INFO)Marshal.PtrToStructure(current, typeof(WTS_SESSION_INFO));
                        int bytesReturned;

                        IntPtr userPtr;
                        WTSQuerySessionInformation(IntPtr.Zero, sessionInfo.SessionID, WTSInfoClass.WTSUserName, out userPtr, out bytesReturned);
                        string userName = Marshal.PtrToStringAnsi(userPtr);
                        WTSFreeMemory(userPtr);

                        sessionList.Add(new RdpSessionInfo
                        {
                            SessionID = sessionInfo.SessionID,
                            UserName = userName,
                            SessionState = sessionInfo.State.ToString(),
                            LogonTime = null,
                            Error = null
                        });

                        current += dataSize;
                    }

                    WTSFreeMemory(ppSessionInfo);
                }
            }
            catch (Exception ex)
            {
                sessionList.Add(new RdpSessionInfo
                {
                    Error = "[Exception] " + ex.Message
                });
            }

            return sessionList;
        }
    }
}
