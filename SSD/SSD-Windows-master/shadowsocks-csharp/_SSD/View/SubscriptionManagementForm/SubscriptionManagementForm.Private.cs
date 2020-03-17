using Shadowsocks.Controller;
using System.Drawing;

namespace Shadowsocks.View {
    public partial class SubscriptionManagementForm {
        private void CheckSelected() {
            if(ListBox_subscription.SelectedIndex == -1) {
                Button_save.Enabled = false;
                Button_delete.Enabled = false;
            }
            else {
                Button_save.Enabled = true;
                Button_delete.Enabled = true;
            }
        }

        private void EnableSwitch() {
            ListBox_subscription.Enabled = !RefreshSwitch;
            TextBox_url.Enabled = !RefreshSwitch;
            Button_add.Enabled = !RefreshSwitch;
            Button_save.Enabled = false;
            Button_delete.Enabled = false;
            RefreshSwitch = !RefreshSwitch;
            CheckSelected();
        }

        private void ResetShowed() {
            TextBox_url.Text = "";
            TextBox_name.Text = "";
            ListBox_subscription.SelectedIndex = -1;
            CheckSelected();
            Label_traffic.Text = "?/? G";
            Label_expiry.Text = "????-??-?? " + I18N.GetString("{0}d", "?");
            CheckBox_use_proxy.Checked = false;
            CheckBox_use_proxy.Enabled = false;
        }
    }
}
