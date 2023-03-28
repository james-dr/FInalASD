using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class TwentyPenceHandler : CoinHandler {

        public TwentyPenceHandler(CoinHandler next) : base(next) { }
        public override bool HandleCoin(Transaction trans, bool method, VendingMachine machine) {
            int coinInMachine = machine.change.twentyPence.Quantity;
            decimal coinVal = machine.change.twentyPence.Value;
            if (method.Equals(false)) {
                machine.change.twentyPence.Quantity += trans.MoneyReceived.twentyPence.Quantity;
                return Next.HandleCoin(trans, method, machine);
            }
            else {
                int coinsToGive = (int)(Math.Floor(trans.ChangeLeft / coinVal));
                if (coinsToGive >= 1) {
                    if (coinsToGive > coinInMachine) {
                        coinsToGive = coinInMachine;
                        machine.change.twentyPence.Quantity = 0;
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.twentyPence.Quantity += coinsToGive;
                    } 
                    else {
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.twentyPence.Quantity += coinsToGive;
                        machine.change.twentyPence.Quantity -= coinsToGive;
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
