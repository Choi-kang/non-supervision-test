namespace Shadowsocks.Controller {
    public partial class ShadowsocksController {
        private void _ArrangeCurrentConfig() {
            GetCurrentConfiguration().ArrangeConfig();
        }
    }
}
