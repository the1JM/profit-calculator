using System;
using System.Collections.Generic;

namespace ProfitCalculatorApp
{
    // A Business holds the fixed information about one company and the
    // transaction history that belongs to it while the app is running.
    public class Business
    {
        // This name is shown in the home screen list and is also written to disk
        // so saved transactions can be matched back to the right business.
        public string Name { get; set; }
        // Type controls which transaction-entry fields are used in the detail form.
        // In this project the expected values are "Sales" and "Service".
        public string Type { get; set; }
        // State is stored as part of the business profile and shown in the header area.
        public string State { get; set; }
        // TaxRate is stored as a percentage value, not as a decimal fraction.
        public decimal TaxRate { get; set; }
        // Grey market businesses are treated as untaxed inside the calculator.
        public bool IsGreyMarket { get; set; }

        // Each business keeps its own transactions so totals and reports can be
        // generated directly from the object without a separate lookup structure.
        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public override string ToString()
        {
            // Returning the name makes the object easier to recognize in debugging
            // and in any control that might display the object directly.
            return Name;
        }

    }
}
