namespace MiniBankAPI.Models;

public class Account {
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyCode { get; set; } = "PLN";
    public byte[] Timestamp { get; set; }
}