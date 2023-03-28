using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class TenPenceHandler : CoinHandler {

        public TenPenceHandler(CoinHandler next) : base(next) { }
        public override bool HandleCoin(Transaction trans, bool method, VendingMachine machine) {
            int coinInMachine = machine.change.tenPence.Quantity;
            decimal coinVal = machine.change.tenPence.Value;
            if (method.Equals(false)) {
                machine.change.tenPence.Quantity += trans.MoneyReceived.tenPence.Quantity;
                return Next.HandleCoin(trans, method, machine);
            }
            else {
                int coinsToGive = (int)(Math.Floor(trans.ChangeLeft / coinVal));
                if (coinsToGive >= 1) {
                    if (coinsToGive > coinInMachine) {
                        coinsToGive = coinInMachine;
                        machine.change.tenPence.Quantity = 0;
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.tenPence.Quantity += coinsToGive;
                    } 
                    else {
                        trans.ChangeLeft -= coinsToGive * coinVal;
                        trans.ChangeGiven.tenPence.Quantity += coinsToGive;
                        machine.change.tenPence.Quantity -= coinsToGive;
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
