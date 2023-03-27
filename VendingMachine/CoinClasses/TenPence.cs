using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinClasses {
    internal class TenPence : Coin {

        public TenPence(int quantity) : base(quantity) {
            this.Value = (decimal)0.1;
        }
    }
}
