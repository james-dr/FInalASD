using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal abstract class CoinHandler {
        protected CoinHandler Next { get; set; }

        public CoinHandler(CoinHandler next) {
            Next = next ?? null;
        }

        public abstract bool HandleCoin(Transaction trans, bool method, VendingMachine machine);
    }
}
