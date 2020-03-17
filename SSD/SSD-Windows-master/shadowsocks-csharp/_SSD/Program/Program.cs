using Shadowsocks.Controller;
using Shadowsocks.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Shadowsocks {
    public static partial class Program {
        private static void _ReleasePlugin() {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if(Environment.Is64BitOperatingSystem) {
                File.WriteAllBytes(Path.Combine(directory, "simple-obfs.exe"), Resources.obfs_local_x64);
                File.WriteAllBytes(Path.Combine(directory, "v2ray.exe"), Resources.v2ray_plugin_windows_amd64);
                File.WriteAllBytes(Path.Combine(directory, "kcptun.exe"), Resources.client_windows_amd64);
                File.WriteAllBytes(Path.Combine(directory, "v2ray.exe"), Resources.v2ray_plugin_windows_amd64);
            }
            else {
                File.WriteAllBytes(Path.Combine(directory, "simple-obfs.exe"), Resources.obfs_local_x86);
                File.WriteAllBytes(Path.Combine(directory, "kcptun.exe"), Resources.client_windows_386);
                File.WriteAllBytes(Path.Combine(directory, "v2ray.exe"), Resources.v2ray_plugin_windows_386);
            }
        }
        private static void _UnexpectedError(bool UI, string message) {
            string textUI = UI ? "UI" : "non-UI";
            MessageBox.Show(
                $"{I18N.GetString("Unexpected error, shadowsocks will exit. Please report to")} https://github.com/TheCGDF/SSD-Windows/issues {Environment.NewLine}{message}",
                "Shadowsocks " + textUI + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
