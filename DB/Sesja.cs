using Microsoft.EntityFrameworkCore;
using MiniBankAPI.Models;

namespace MiniBankAPI.DB;

public class Sesja : DbContext
{
    public Sesja(DbContextOptions<Sesja> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<BankProfit> BankProfits { get; set; }
    public DbSet<ExchangeRate> ExchangeRates { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder model_builder)
    {
        base.OnModelCreating(model_builder);

        model_builder.Entity<Account>(encja =>
        {
            encja.HasKey(e => e.Id);
            encja.Property(e => e.Balance).HasPrecision(18, 2);
            encja.Property(e => e.CurrencyCode).HasMaxLength(3);
            encja.Property(e => e.Timestamp).IsRowVersion();
        });

        model_builder.Entity<Transaction>(encja =>
        {
            encja.HasKey(e => e.Id);
            encja.Property(e => e.Amount).HasPrecision(18, 2);
            encja.Property(e => e.CurrencyCode).HasMaxLength(3);
            encja.HasIndex(e => e.IdempotencyKey).IsUnique();
        });

        model_builder.Entity<ExchangeRate>(encja =>
        {
            encja.HasKey(e => e.Id);
            encja.Property(e => e.CurrencyCode).HasMaxLength(3);
            encja.Property(e => e.BuyRate).HasPrecision(18, 4);
            encja.Property(e => e.SellRate).HasPrecision(18, 4);
        });

        model_builder.Entity<BankProfit>(encja =>
        {
            encja.HasKey(e => e.Id);
            encja.Property(e => e.Amount).HasPrecision(18, 2);
        });
    }
}