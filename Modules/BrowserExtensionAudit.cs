using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonitoringAgent.Models;
using System.IO;
using System.Text.Json;


namespace MonitoringAgent.Modules
{
    public static class BrowserExtensionAudit
    {
        public static List<BrowserExtensionInfo> GetInstalledExtensions()
        {
            var extensions = new List<BrowserExtensionInfo>();

            try
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var roamingAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // Chrome
                string chromeExtensionsPath = Path.Combine(localAppData, "Google", "Chrome", "User Data", "Default", "Extensions");
                if (Directory.Exists(chromeExtensionsPath))
                    extensions.AddRange(ParseChromeOrEdgeExtensions(chromeExtensionsPath, "Chrome"));

                // Edge
                string edgeExtensionsPath = Path.Combine(localAppData, "Microsoft", "Edge", "User Data", "Default", "Extensions");
                if (Directory.Exists(edgeExtensionsPath))
                    extensions.AddRange(ParseChromeOrEdgeExtensions(edgeExtensionsPath, "Edge"));

                // Firefox
                string firefoxProfilesPath = Path.Combine(roamingAppData, "Mozilla", "Firefox", "Profiles");
                if (Directory.Exists(firefoxProfilesPath))
                {
                    foreach (var profileDir in Directory.GetDirectories(firefoxProfilesPath))
                    {
                        string addonJson = Path.Combine(profileDir, "addons.json");
                        if (File.Exists(addonJson))
                        {
                            var json = File.ReadAllText(addonJson);
                            using var doc = JsonDocument.Parse(json);
                            if (doc.RootElement.TryGetProperty("addons", out var addons))
                            {
                                foreach (var addon in addons.EnumerateArray())
                                {
                                    extensions.Add(new BrowserExtensionInfo
                                    {
                                        Browser = "Firefox",
                                        Name = addon.GetProperty("defaultLocale").GetProperty("name").GetString(),
                                        ID = addon.GetProperty("id").GetString(),
                                        Version = addon.GetProperty("version").GetString(),
                                        IsEnabled = addon.GetProperty("active").GetBoolean()
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return extensions;
        }

        private static List<BrowserExtensionInfo> ParseChromeOrEdgeExtensions(string basePath, string browserName)
        {
            var list = new List<BrowserExtensionInfo>();

            foreach (var extIdDir in Directory.GetDirectories(basePath))
            {
                var versions = Directory.GetDirectories(extIdDir);
                var latestVersionDir = versions.OrderByDescending(v => v).FirstOrDefault();
                if (latestVersionDir != null)
                {
                    string manifestPath = Path.Combine(latestVersionDir, "manifest.json");
                    if (File.Exists(manifestPath))
                    {
                        var json = File.ReadAllText(manifestPath);
                        using var doc = JsonDocument.Parse(json);

                        string name = doc.RootElement.TryGetProperty("name", out var nameProp) ? nameProp.GetString() : "Unknown";
                        string version = doc.RootElement.TryGetProperty("version", out var versionProp) ? versionProp.GetString() : "Unknown";

                        // Fix __MSG_xxx__ names using messages.json
                        if (name != null && name.StartsWith("__MSG_") && name.EndsWith("__"))
                        {
                            string msgKey = name.TrimStart('_').TrimEnd('_').Replace("MSG_", "");
                            string localePath = Path.Combine(latestVersionDir, "_locales", "en", "messages.json");
                            if (File.Exists(localePath))
                            {
                                var localeJson = File.ReadAllText(localePath);
                                using var localeDoc = JsonDocument.Parse(localeJson);
                                if (localeDoc.RootElement.TryGetProperty(msgKey, out var msgValue))
                                {
                                    name = msgValue.GetProperty("message").GetString();
                                }
                            }
                        }

                        list.Add(new BrowserExtensionInfo
                        {
                            Browser = browserName,
                            Name = name,
                            ID = Path.GetFileName(extIdDir),
                            Version = version,
                            IsEnabled = true
                        });
                    }
                }
            }

            return list;
        }
    }
}

