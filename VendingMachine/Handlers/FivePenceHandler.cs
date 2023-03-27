using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class FivePenceHandler : CoinHandler {

        public FivePenceHandler(CoinHandler next) : base(next) { }
        public override bool HandleCoin(Transaction trans, bool method, VendingMachine machine) {
            int coinInMachine = machine.change.fivePence.Quantity;
            decimal coinVal = machine.change.fivePence.Value;
            if (method.Equals(false)) {
                machine.change.fivePence.Quantity += trans.MoneyReceived.fivePence.Quantity;
                return true;
            }
            else {
                int coinsToGive = (int)(Math.Floor(trans.ChangeLeft / coinVal));
                if (coinsToGive >= 1) {
                    if (coinsToGive > coinInMachine) {
                        coinsToGive = coinInMachine;
                        machine.change.fivePence.Quantity = 0;
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.fivePence.Quantity += coinsToGive;
                    } 
                    else {
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.fivePence.Quantity += coinsToGive;
                        machine.change.fivePence.Quantity -= coinsToGive;
                    }
                }
                if (trans.ChangeLeft > 0) {
                    return false;
                }
                return true;

            }
        }

    }
}
