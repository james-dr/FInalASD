using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class VendingMachine {
        public List<Snack> SnacksForSale { get; set; }
        public CoinPool change { get; set; }
        public Admin Admin { get; set; }

        public VendingMachine(List<Snack> snacks, CoinPool change) {
            SnacksForSale = snacks;
            this.change = change;
            Admin = new Admin(1011, "A5144l");
        }
         public string GetSnackData() {
            string snackData = "";
            int snackIndex = 1;
            foreach (Snack snack in SnacksForSale) {
                snackData += String.Format("{0, -3} {1}\n", snackIndex.ToString() + ".", snack.ToString());
                snackIndex++;
            }
            return snackData;
        }
        public bool CheckItemAvailability(int itemIndex) {
            if (SnacksForSale[itemIndex].SnackQuantity <= 0) {
                return false;
            }
            
            return true;
        }
        public int ProcessMoney(CoinPool coins, bool getChange, int item = 0) {

            if (getChange.Equals(true)) {
                Transaction newTrans = new Transaction(coins, SnacksForSale[item]);
                double initial = SnacksForSale[item].SnackPrice;
                if (coins.GetTotal() < initial) {
                    return 0;
                }
                CoinHandler cashier = GetCashier();
                VendingMachine m1 = this;
                cashier.HandleCoin(newTrans, false, m1);
                // Console.WriteLine(newTrans.MoneyReceived.ToString());
                if (cashier.HandleCoin(newTrans, true, m1).Equals(false)) {
                    return 1;
                }
                SnacksForSale[item].SnackQuantity--;
                Console.WriteLine(newTrans.ChangeGiven.ToString());
                Console.ReadLine();
                return 2;
            }
            else {
                Transaction newTrans = new Transaction(coins);
                CoinHandler cashier = GetCashier();
                VendingMachine m1 = this;
                cashier.HandleCoin(newTrans, false, m1);
                return 2;
            }
        }
        private CoinHandler GetCashier() {
            CoinHandler twoHandler = new TwoPoundHandler(new OnePoundHandler(new FiftyPenceHandler(new TwentyPenceHandler(new TenPenceHandler(new FivePenceHandler(null))))));
            return twoHandler;
        }

        public void ChangeSnackPrice(int SnackNum, double NewPrice) {
            int SnackPos = SnackNum - 1;
            SnacksForSale[SnackPos].SnackPrice = NewPrice;

            Console.WriteLine(SnacksForSale[SnackPos] + " price changed to " + NewPrice);
        }

    }
}
