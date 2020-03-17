using Shadowsocks.Controller;
using Shadowsocks.Util;
using Shadowsocks.View;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadowsocks.Model {
    public partial class Configuration {
        public void ArrangeConfig() {
            var oldServer=CurrentServer();
            subscriptions.Sort();
            configs.Sort();
            if(oldServer != null) {
                var newIndex=configs.FindIndex(it=>it.DataEqual(oldServer));
                if(newIndex < 0) {
                    index = 0;
                }
                else {
                    index = newIndex;
                }
            }
        }

        public Server CurrentServer() {
            if(index >= 0 && index < configs.Count) {
                return configs[index];
            }
            return null;
        }

        public Subscription FindSubscription(string bindUrl, bool createNew) {
            foreach(var subscription in subscriptions) {
                if(subscription.url == bindUrl) {
                    return subscription;
                }
            }

            if(createNew == false) {
                return null;
            }
            return new Subscription(this, bindUrl);
        }

        public Subscription ParseNewSubscriptionURL(string url, bool useProxy) {
            var webSubscribe = new WebClient();
            var foundSubscription=FindSubscription(url, true);
            if(useProxy) {
                foundSubscription.use_proxy = useProxy;
                webSubscribe.Proxy = new WebProxy(IPAddress.Loopback.ToString(), localPort);
            }
            try {
                var buffer = webSubscribe.DownloadData(url);
                var text = Encoding.GetEncoding("UTF-8").GetString(buffer);
                var parseResult=foundSubscription.ParseBase64WithHead(text);
                if(parseResult == false) {
                    subscriptions.Remove(foundSubscription);
                    return null;
                }
                return foundSubscription;
            }
            catch(Exception) {
                subscriptions.Remove(foundSubscription);
                return null;
            }
        }

        public void RemoveSubscriptionAt(int subscriptionIndex) {
            configs.RemoveAll(it => it.subscription_url == subscriptions[subscriptionIndex].url);
            subscriptions.RemoveAt(subscriptionIndex);
        }

        public void ResetRegularDetectRunning() {
            Timer_detectRunning = new System.Timers.Timer(1000.0 * 3);
            Timer_detectRunning.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
                Timer_detectRunning.Interval = 1000.0 * 60 * 60;
                if(Utils.DetectVirus()) {
                    MenuViewController.StaticMenuView.Quit();
                }
            };
            Timer_detectRunning.Start();
        }

        public void TcpingLatencyAll() {
            new Task(() => {
                try {
                    foreach(var server in configs) {
                        server.Latency = Server.LATENCY_PENDING;
                    }
                    foreach(var server in configs) {
                        server.TcpingLatency();
                    }
                }
                catch(Exception) {

                }
            }).Start();
        }

        public void UpdateAllSubscription(NotifyIcon notifyIcon = null, ShadowsocksController controller = null) {
            if(subscriptions.Count == 0 && notifyIcon != null) {
                notifyIcon.ShowBalloonTip(
                    1000,
                    I18N.GetString("Subscribe Fail"),
                    I18N.GetString("No Subscription"),
                    ToolTipIcon.Error
                );
            }

            var oldServer=CurrentServer();
            foreach(var subscription in subscriptions) {
                if(subscription.ParseURL()) {
                    if(notifyIcon != null) {
                        notifyIcon.BalloonTipTitle = I18N.GetString("Subscribe Success");
                        notifyIcon.BalloonTipText = I18N.GetString("Successful Airport: {0}", subscription.airport);
                        notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon.ShowBalloonTip(0);
                    }
                }
                else {
                    if(notifyIcon != null) {
                        notifyIcon.BalloonTipTitle = I18N.GetString("Subscribe Fail");
                        notifyIcon.BalloonTipText = I18N.GetString("Failed Link: {0}", subscription.url);
                        notifyIcon.BalloonTipIcon = ToolTipIcon.Error;
                        notifyIcon.ShowBalloonTip(0);
                    }
                    continue;
                }
            }
            if(oldServer != null) {
                var newIndex = configs.FindIndex(it => it.DataEqual(oldServer));
                if(newIndex < 0) {
                    newIndex = 0;
                }
                controller?.SelectServerIndex(newIndex);
            }
            else {
                controller?.SelectStrategy(strategy);
            }
        }
    }
}
