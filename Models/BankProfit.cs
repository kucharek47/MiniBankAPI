namespace MiniBankAPI.Models;

public class BankProfit {
    public int Id { get; set; }
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
}