using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class TwoPoundHandler : CoinHandler {

        public TwoPoundHandler(CoinHandler next) : base(next) { }
        public override bool HandleCoin(Transaction trans, bool method, VendingMachine machine) {
            int coinInMachine = machine.change.twoPound.Quantity;
            decimal coinVal = machine.change.twoPound.Value;
            if (method.Equals(false)) {
                machine.change.twoPound.Quantity += trans.MoneyReceived.twoPound.Quantity;
                return Next.HandleCoin(trans, method, machine);
            }
            else {
                int coinsToGive = (int)Math.Floor(trans.ChangeLeft / coinVal);
                if (coinsToGive >= 1) {
                    if (coinsToGive > coinInMachine) {
                        coinsToGive = coinInMachine;
                        machine.change.twoPound.Quantity = 0;
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.twoPound.Quantity += coinsToGive;
                    } 
                    else {
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.twoPound.Quantity += coinsToGive;
                        machine.change.twoPound.Quantity -= coinsToGive;
                    }
                }
                if (trans.ChangeLeft > 0) {
                    return Next.HandleCoin(trans, method, machine);
                }
                return true;

            }
        }

    }
}
