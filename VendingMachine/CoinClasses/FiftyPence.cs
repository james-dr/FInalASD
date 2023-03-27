using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinClasses {
    internal class FiftyPence: Coin {

        public FiftyPence(int quantity) : base(quantity) {
            this.Value = (decimal)0.5;
        }
    }
}
