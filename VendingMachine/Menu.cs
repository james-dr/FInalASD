using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CoinClasses;

namespace VendingMachine {
    internal class Menu {
        public VendingMachine machine { get;  }
        public Menu(VendingMachine machine) {
            this.machine = machine;       
        }
        public void MainMenu() {
            Console.Clear();
            Console.WriteLine("###############################");
            Console.WriteLine("# Mecachrome Vending Merchant #");
            Console.WriteLine("#     Hawking Edible Wares    #");
            Console.WriteLine(" #############################");
            Console.WriteLine(String.Format("{0,-4}{1,-10} -- {2,-6} -- {3,-10}", "", "Snack", "Price", "QTY"));
            Console.WriteLine(machine.GetSnackData());
            Console.Write("Please enter choice: > ");
            try {
                int choice = Convert.ToInt32(Console.ReadLine()) - 1;
                if (choice + 1 == machine.Admin.Code) {
                    Console.Write("Password: ");
                    string passwd = Console.ReadLine();
                    if (passwd.Equals(machine.Admin.Passwd)) {
                        AdminMenu();
                    }
                }
                TransactionMenu(choice);
            }
            catch (Exception e) {
                //Console.WriteLine(e);
                Console.WriteLine("Error occured, try again. (Enter to continue)");
                Console.ReadLine();
            }
            MainMenu();
        }
        
        public void AdminMenu() {
            while (true) {
                Console.Clear();
                Console.WriteLine("###############################");
                Console.WriteLine("#         Admin Menu          #");
                Console.WriteLine("###############################");
                Console.WriteLine("1. Change a snack price");
                Console.WriteLine("2. Increase change pool");
                Console.WriteLine("3. See total money in machine");
                Console.WriteLine("4. Return to menu");
                Console.Write("Choose option: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 4) {
                    break;
                }
                switch (choice) {

                    case 1:
                        //Reprint available snack info
                        Console.WriteLine(String.Format("{0,-4}{1,-10} -- {2,-6} -- {3,-10}", "", "Snack", "Price", "QTY"));
                        Console.WriteLine(machine.GetSnackData());

                        //Snack number the user wants to change the price for
                        Console.WriteLine("Please enter the number of the snack you wish to change the price for: > ");
                        int sNum = Convert.ToInt32(Console.ReadLine());

                        //New snack price
                        Console.WriteLine("Please enter the new price: > ");
                        double sPrice = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);

                        //Invoke ChangeSnackPrice method from Machine class
                        machine.ChangeSnackPrice(sNum, sPrice);
                        break;
                    case 2:
                        Console.Clear();
                        CoinPool coinsReceived = new CoinPool(new TwoPound(0), new OnePound(0), new FiftyPence(0), new TwentyPence(0), new TenPence(0), new FivePence(0));
                        Coin[] coins = { coinsReceived.twoPound, coinsReceived.onePound, coinsReceived.fiftyPence, coinsReceived.twentyPence, coinsReceived.tenPence, coinsReceived.fivePence };
                        foreach (Coin coin in coins) {
                            Console.WriteLine($"Number of {String.Format("{0:0.00}", coin.Value)}, coins inserted: ");
                            int numInserted = Convert.ToInt32(Console.ReadLine());
                            coin.Quantity += numInserted;
                            }
                        machine.ProcessMoney(coinsReceived, false);
                        break;
                    case 3:
                        // Invoke GetTotalChange method from Machine class
                        Console.WriteLine(machine.change.GetTotal());
                        Console.WriteLine("Press any button to continue");
                        Console.ReadLine();
                        break;
                }
            }
            MainMenu();
        }
        
        private void TransactionMenu(int choice) {

            // Check item availability

            if ( !machine.CheckItemAvailability(choice)) {
                Console.WriteLine("* out of stock *");
                Console.ReadLine();
                return;
            }
            // Receive money

            // Loo
            Console.WriteLine("## Enter coins to pay ##");

            bool Paid = false;
            while (Paid.Equals(false)) {

                CoinPool coinsReceived = new CoinPool(new TwoPound(0), new OnePound(0), new FiftyPence(0), new TwentyPence(0), new TenPence(0), new FivePence(0));
                Coin[] coins = { coinsReceived.twoPound, coinsReceived.onePound, coinsReceived.fiftyPence, coinsReceived.twentyPence, coinsReceived.tenPence, coinsReceived.fivePence };
                foreach (Coin coin in coins) {
                    Console.WriteLine($"Number of {String.Format("{0:0.00}", coin.Value)}, coins inserted: ");
                    int numInserted = Convert.ToInt32(Console.ReadLine());
                    coin.Quantity += numInserted;
                    if (machine.ProcessMoney(coinsReceived, true, choice).Equals(2)) {
                        Paid = true;
                        break;
                    }
                }
                if (Paid.Equals(false)) {
                    Console.WriteLine("Not enough coins inserted.");
                }
            }
        }
    }
}
