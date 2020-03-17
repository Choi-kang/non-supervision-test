using System;

namespace Shadowsocks.Model {
    public partial class Subscription :IComparable<Subscription> {
        public int CompareTo(Subscription compared) {
            var airportCompare= airport.CompareTo(compared.airport);
            if(airportCompare != 0) {
                return airportCompare;
            }
            return url.CompareTo(compared.url);
        }
    }
}
