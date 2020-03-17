using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowsocks.Model {
    public partial class Server :IComparable<Server> {
        public int CompareTo(Server compared) {
            if(subscription_url == "") {
                if(compared.subscription_url == "") {
                    return FriendlyName().CompareTo(compared.FriendlyName());
                }
                else {
                    return -1;
                }
            }

            if(compared.subscription_url == "") {
                return 1;
            }

            var subscriptionCompare= Subscription.CompareTo(compared.Subscription);

            if(subscriptionCompare != 0) {
                return subscriptionCompare;
            }
            return id.CompareTo(compared.id);
        }
    }
}
