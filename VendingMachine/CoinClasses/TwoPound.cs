using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinClasses {
    internal class TwoPound : Coin {

        public TwoPound(int quantity) : base(quantity) {
            this.Value = 2;
        }
    }
}
