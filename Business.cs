using System;
using System.Collections.Generic;

namespace ProfitCalculatorApp
{
    public class Business
    {
        public string Name { get; set; }
        public string Type { get; set; }  // "Sales" or "Service"
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public bool IsGreyMarket { get; set; }

        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public override string ToString()
        {
            return Name;
        }

    }
}
