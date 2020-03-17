using Shadowsocks.Model;

namespace Shadowsocks.View {
    public partial class ConfigForm {
        private void _SaveSubscriptionServer(Server server) {
            server.id = _modifiedConfiguration.configs[_lastSelectedIndex].id;
            server.Subscription = _modifiedConfiguration.configs[_lastSelectedIndex].Subscription;
            server.ratio = _modifiedConfiguration.configs[_lastSelectedIndex].ratio;
        }

        private void _LoadSubscriptionServerNameList(Configuration modifiedConfiguration) {
            ServersListBox.Items.Clear();
            foreach(var server in modifiedConfiguration.configs) {
                var ServerText=server.FriendlyName();
                if(server.subscription_url != "") {
                    ServerText = server.NamePrefix(modifiedConfiguration, Server.PREFIX_LIST) + server.remarks;
                }
                ServersListBox.Items.Add(ServerText);
            }
        }

        private void _SetLastSubscriptionName() {
            var server=_modifiedConfiguration.configs[_lastSelectedIndex];
            if(server.subscription_url != "") {
                ServersListBox.Items[_lastSelectedIndex] = server.NamePrefix(_modifiedConfiguration, Server.PREFIX_LIST) + server.remarks;
            }
        }

        private void _DisableMove() {
            MoveUpButton.Visible = false;
            MoveDownButton.Visible = false;
        }
    }
}
