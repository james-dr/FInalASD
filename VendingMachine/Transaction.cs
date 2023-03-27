using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CoinClasses;

namespace VendingMachine {
    internal class Transaction {
        public CoinPool MoneyReceived { get; set; }
        public CoinPool ChangeGiven { get; set; }
        public decimal AmountCharged { get; set; }
        public decimal ChangeLeft { get; set; }

        public Transaction(CoinPool moneyReceived, Snack itemBought) {
            MoneyReceived = moneyReceived;
            AmountCharged = (decimal)itemBought.SnackPrice;
            ChangeGiven = new CoinPool(new TwoPound(0), new OnePound(0), new FiftyPence(0), new TwentyPence(0), new TenPence(0), new FivePence(0));
            ChangeLeft = (decimal)MoneyReceived.GetTotal() - AmountCharged;
            
        }
        public Transaction(CoinPool money) {
            MoneyReceived = money;
        }
    }
}
