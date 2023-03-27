using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CoinClasses;

namespace VendingMachine {
    internal class CoinPool {
        public TwoPound twoPound { get; set; }
        public OnePound onePound { get; set; }
        public FiftyPence fiftyPence { get; set; }
        public TwentyPence twentyPence { get; set; }
        public TenPence tenPence { get; set; }
        public FivePence fivePence { get; set; }
        
        public CoinPool(TwoPound two, OnePound one, FiftyPence fifty, TwentyPence twenty, TenPence ten, FivePence five) {
            twoPound = two;
            onePound = one;
            fiftyPence = fifty;
            twentyPence = twenty;
            tenPence = ten;
            fivePence = five;               
        }

        public double GetTotal() {
            Coin[] coins = { twoPound, onePound, fiftyPence, twentyPence, tenPence, fivePence };
            double total = 0;
            foreach (Coin coin in coins) {
                total += (double) (coin.Value * coin.Quantity);
            }
            return total;
        }
        public override string ToString() {
            Coin[] coins = { twoPound, onePound, fiftyPence, twentyPence, tenPence, fivePence };
            string returnstring = "";
            foreach (Coin coin in coins) {
                returnstring += $"{coin.Value}: {coin.Quantity}\n";
            }
            return returnstring;
        }
    }
}
