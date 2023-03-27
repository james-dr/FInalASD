using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinClasses {
    internal class OnePound : Coin {

        public OnePound(int quantity) : base(quantity) {
            this.Value = 1;
        }
    }
}
