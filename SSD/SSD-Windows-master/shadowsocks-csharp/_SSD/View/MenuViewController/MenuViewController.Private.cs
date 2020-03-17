using Shadowsocks.Model;
using System;

namespace Shadowsocks.View {
    public partial class MenuViewController {
        private void PreloadMenu(object sender, EventArgs e) {
            UpdateServersMenu();
        }

        private void SubscriptionManagement(object sender, EventArgs e) {
            Configuration.Save(ConfigurationCurrent);
            if(Form_subscriptionManagement == null) {
                Form_subscriptionManagement = new SubscriptionManagementForm(controller);
                Form_subscriptionManagement.Show();
                Form_subscriptionManagement.FormClosed += SubscriptionSettingsRecycled;
            }
            Form_subscriptionManagement.Activate();
        }

        private void SubscriptionSettingsRecycled(object sender, EventArgs e) {
            Form_subscriptionManagement.Dispose();
            Form_subscriptionManagement = null;
            if(ConfigurationCurrent.strategy == null) {
                controller.SelectServerIndex(ConfigurationCurrent.index);
            }
            else {
                controller.SelectStrategy(ConfigurationCurrent.strategy);
            }
        }

        private void UpdateSubscription(object sender, EventArgs e) {
            ConfigurationCurrent.UpdateAllSubscription(_notifyIcon, controller);
        }
    }
}
