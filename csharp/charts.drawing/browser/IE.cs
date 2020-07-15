using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace charts.drawing {
    public class IE {
        private static readonly Dictionary<Version, Object> versionList = new Dictionary<Version, Object>();
        static IE() {
            versionList.Add(Version.IE7, 0x1B58); // 7000
            versionList.Add(Version.IE8, 0x1F40); // 8000
            versionList.Add(Version.IE9, 0x2328); // 9000
            versionList.Add(Version.IE10, 0x02710); // 10000
            versionList.Add(Version.IE11, 0x2AF8);  // 11000

            versionList.Add(Version.IE8Ex, 0x22B8); // 8888
            versionList.Add(Version.IE9Ex, 0x270F); // 9999
            versionList.Add(Version.IE10Ex, 0x2711); // 10001
            versionList.Add(Version.IE11Ex, 0x2EDF); // 11001
        }

        public static void SetVersion(Version version) {
            String productName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            if (productName == null) {
                productName = AppDomain.CurrentDomain.FriendlyName; // .NET2.0
            }

            RegistryKey feature_browser_emulation = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            if (feature_browser_emulation != null) {
                feature_browser_emulation.SetValue(
                    productName,
                    versionList.ContainsKey(version) ? versionList[version] : "",
                    RegistryValueKind.DWord);
                feature_browser_emulation.Close();
                //feature_browser_emulation.Dispose();
            }
        }

        public enum Version {
            IE7,
            IE8,
            IE9,
            IE10,
            IE11,

            IE8Ex,
            IE9Ex,
            IE10Ex,
            IE11Ex,
        }
    }
}
