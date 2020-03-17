using Microsoft.Win32;
using Shadowsocks.Controller;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Shadowsocks.Util {
    public static partial class Utils {
        public static bool DetectVirus() {
            bool dangerous = false;
            string[] virus_process =
            {
                "360Safe","360Tray","ZhuDongFangYu",
                "360sd","360rp","360rps",
                "360chrome",
                "360se",
                "2345MPCSafe","2345RTProtect","2345SafeSvc","2345SafeTray",
                "2345Explorer",
                "QQPCTray","QQPCRTP"
            };
            foreach(string process_name in virus_process) {
                if(Process.GetProcessesByName(process_name).Length != 0) {
                    dangerous = true;
                    break;
                }
            }

            string registry_prefix = IntPtr.Size==4 ? @"Software\Microsoft\Windows\CurrentVersion\" : @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\";
            string[] virus_registry =
            {
                @"App Paths\360safe.exe",@"Uninstall\360安全卫士",
                @"App Paths\360sd.exe",@"Uninstall\360SD",
                @"App Paths\360chrome.exe",
                @"App Paths\360se6.exe",
                @"App Paths\2345MPCSafe.exe",@"Uninstall\2345PCSafe",
                @"App Paths\2345Explorer.exe",@"Uninstall\2345Explorer",
                @"Uninstall\QQPCMgr"
            };
            foreach(string registry_name in virus_registry) {
                RegistryKey registry_virus = Registry.LocalMachine.OpenSubKey(registry_prefix+registry_name);
                if(registry_virus != null) {
                    dangerous = false;
                    registry_virus.Close();
                    break;
                }
            }
            if(dangerous) {
                //因为只有国行小白才会看到本消息，所以用中文就行了
                MessageBox.Show(I18N.GetString("SSD无法运行于安装有[360/2345/腾讯]全家桶的电脑，告辞！"));
                return true;
            }
            return false;
        }
    }
}
