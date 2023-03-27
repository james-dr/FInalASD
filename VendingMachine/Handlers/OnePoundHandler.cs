using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class OnePoundHandler : CoinHandler {

        public OnePoundHandler(CoinHandler next) : base(next) { }
        public override bool HandleCoin(Transaction trans, bool method, VendingMachine machine) {
            int coinInMachine = machine.change.onePound.Quantity;
            decimal coinVal = machine.change.onePound.Value;
            if (method.Equals(false)) {
                machine.change.onePound.Quantity += trans.MoneyReceived.onePound.Quantity;
                return Next.HandleCoin(trans, method, machine);
            } else {
                int coinsToGive = (int)(Math.Floor(trans.ChangeLeft / coinVal));
                if (coinsToGive >= 1) {
                    if (coinsToGive > coinInMachine) {
                        coinsToGive = coinInMachine;
                        machine.change.onePound.Quantity = 0;
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.twoPound.Quantity += coinsToGive;
                    } else {
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.twoPound.Quantity += coinsToGive;
                        machine.change.onePound.Quantity -= coinsToGive;
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
