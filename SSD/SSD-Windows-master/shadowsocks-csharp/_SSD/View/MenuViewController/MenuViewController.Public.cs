using System.Windows.Forms;

namespace Shadowsocks.View {
    public partial class MenuViewController {
        public void Quit() {
            Quit_Click(null, null);
        }

        public static void StaticShowBalloonTip(string title, string content, ToolTipIcon icon, int timeout) {
            StaticMenuView.ShowBalloonTip(title, content, icon, timeout);
        }
    }
}
