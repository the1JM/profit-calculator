namespace ProfitCalculatorApp
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Tax { get; set; }
        public decimal Profit { get; set; }
    }
}
