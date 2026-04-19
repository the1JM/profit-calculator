namespace ProfitCalculatorApp
{
    // A Transaction represents one sale or service job that contributes
    // revenue, tax, and profit to a specific business.
    public class Transaction
    {
        // Reports use the transaction date to decide whether the record belongs
        // in a weekly, monthly, or yearly summary.
        public DateTime Date { get; set; }

        // The person or company tied to the transaction.
        public string ClientName { get; set; } = string.Empty;

        // Revenue is the money brought in before tax and cost are subtracted.
        public decimal Revenue { get; set; }

        // Tax is calculated when a transaction is added or edited.
        public decimal Tax { get; set; }

        // Profit is the final amount left after subtracting cost and tax.
        public decimal Profit { get; set; }
    }
}
