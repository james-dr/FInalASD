using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinClasses {
    internal abstract class Coin {

        public decimal Value { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }
        public Coin(int quantity) {
            this.Currency = "£";
            Quantity = quantity;
        }
    }

}
