using Shadowsocks.Controller;
using Shadowsocks.Model;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Shadowsocks.View {
    public partial class MenuViewController {
        private Configuration ConfigurationCurrent;

        private MenuItem MenuGroup_subscribe;
        private MenuItem MenuItem_subscribeManage;
        private MenuItem MenuItem_subscribeUpdate;
        private SubscriptionManagementForm Form_subscriptionManagement;

        public static MenuViewController StaticMenuView=null;//为毛MenuView不设计为单例模式。。。怨念。。。

        private void _SetStaticMenuView() {
            StaticMenuView = this;
        }

        private void _DisableFirstRun() {

        }

        private void _InitOther() {
            ConfigurationCurrent = controller.GetCurrentConfiguration();
            ConfigurationCurrent.ResetRegularDetectRunning();
            contextMenu1.Popup += PreloadMenu;
        }

        private MenuItem _CreateAirportSeperator() {
            return new MenuItem("-");
        }

        private MenuItem _CreateTcpingLatency() {
            return new MenuItem(
                I18N.GetString("Tcping Latency"),
                (sender, e) => {
                    ConfigurationCurrent.TcpingLatencyAll();
                });
        }

        private MenuItem _CreateSubscribeGroup() {
            MenuGroup_subscribe = CreateMenuGroup("Subscription", new MenuItem[] {
                    MenuItem_subscribeManage = CreateMenuItem("Manage", SubscriptionManagement),
                    MenuItem_subscribeUpdate = CreateMenuItem("Update", UpdateSubscription)
                });
            return MenuGroup_subscribe;
        }

        private void _OpenUpdateInfo() {
            Process.Start(UpdateChecker.RELEASE_URL_SSD);
        }

        private Configuration _GetConfigurationCurrent() {
            ConfigurationCurrent = controller.GetCurrentConfiguration();
            return ConfigurationCurrent;
        }

        private MenuItem _AdjustServerName(Server server) {
            return new MenuItem(server.NamePrefix(ConfigurationCurrent, Server.PREFIX_MENU) + " " + server.FriendlyName());
        }

        private void _UpdateAirportMenu(int inherit_index) {
            var items = ServersItem.MenuItems;
            var indexAirport = 0;
            var countSeperator = 0;

            for(; indexAirport <= items.Count - 1; indexAirport++) {
                if(items[indexAirport].Text == "-") {
                    countSeperator++;
                    if(countSeperator == 2) {
                        break;
                    }
                }
            }

            indexAirport++;
            while(items[indexAirport].Text != "-") {
                items.RemoveAt(indexAirport);
            }

            var subscriptions = ConfigurationCurrent.subscriptions;
            for(var index = 0; index <= subscriptions.Count - 1; index++) {
                var MenuItem_airport = new MenuItem(subscriptions[index].NamePrefix() + " " + subscriptions[index].airport);
                foreach(var server in subscriptions[index].GetServers()) {
                    var serverText = server.NamePrefix(ConfigurationCurrent,Server.PREFIX_MENU) + " " + server.FriendlyName();
                    var serverItem = new MenuItem(serverText);
                    serverItem.Tag = inherit_index;
                    serverItem.Click += AServerItem_Click;
                    MenuItem_airport.MenuItems.Add(serverItem);
                    if(ConfigurationCurrent.index == inherit_index) {
                        serverItem.Checked = true;
                        MenuItem_airport.Text = "● " + MenuItem_airport.Text;
                    }
                    inherit_index++;
                }
                items.Add(indexAirport, MenuItem_airport);
                indexAirport++;
            }
        }

        private void _AboutSSD() {
            Process.Start("https://github.com/TheCGDF/SSD-Windows");
        }

        private void _ReplaceUpdate() {
            Process.Start(UpdateChecker.RELEASE_URL_SSD);
        }
    }
}
