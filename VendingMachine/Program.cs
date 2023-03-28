using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CoinClasses;

namespace VendingMachine {
    internal class Program {
        static void Main(string[] args) {
            List<Snack> snacks = new List<Snack>();
            Snack s1 = new Snack("Cola", 1.50, 10);
            Snack s2 = new Snack("Choc Bar", 1.25, 10);
            Snack s3 = new Snack("Skittles", 1.7, 10);
            Snack s4 = new Snack("Bikkies", 1.7, 10);
            
            snacks.Add(s1); snacks.Add(s2); snacks.Add(s4); snacks.Add(s3);
            CoinPool startingChange = new CoinPool(new TwoPound(2), new OnePound(3), new FiftyPence(4), new TwentyPence(5), new TenPence(10), new FivePence(20));
            VendingMachine machine = new VendingMachine(snacks, startingChange);
            Menu menu = new Menu(machine);
            machine.Admin = new Admin(1011, "");
            menu.MainMenu();

        }
    }
}
