namespace MiniBankAPI.Models;

public class Transaction {
    public int Id { get; set; }
    public int SenderAccountId { get; set; }
    public int ReceiverAccountId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; } = "PLN";
    public DateTime Timestamp { get; set; }
    public string IdempotencyKey { get; set; } = string.Empty;
}