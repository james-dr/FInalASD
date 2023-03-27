using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class FiftyPenceHandler : CoinHandler {

        public FiftyPenceHandler(CoinHandler next) : base(next) { }
        public override bool HandleCoin(Transaction trans, bool method, VendingMachine machine) {
            int coinInMachine = machine.change.fiftyPence.Quantity;
            decimal coinVal = machine.change.fiftyPence.Value;
            if (method.Equals(false)) {
                machine.change.fiftyPence.Quantity += trans.MoneyReceived.fiftyPence.Quantity;
                return Next.HandleCoin(trans, method, machine);
            }
            else {
                int coinsToGive = (int)(Math.Floor(trans.ChangeLeft / coinVal));
                if (coinsToGive >= 1) {
                    if (coinsToGive > coinInMachine) {
                        coinsToGive = coinInMachine;
                        machine.change.fiftyPence.Quantity = 0;
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.fiftyPence.Quantity += coinsToGive;
                    } 
                    else {
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.fiftyPence.Quantity += coinsToGive;
                        machine.change.fiftyPence.Quantity -= coinsToGive;
                       // Console.WriteLine(coinChangeAmount);
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
