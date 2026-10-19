using MiniBankAPI.Interfaces;
using MiniBankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniBankAPI.DB;

public static class Admin
{
    public static async Task<bool> ZapisKursow(Sesja db, List<DBSetKurs> kursy)
    {
        var kody = kursy.Select(k => k.Waluta).ToList();

        var zBazy = await db.ExchangeRates
            .Where(e => kody.Contains(e.CurrencyCode))
            .ToListAsync();

        foreach (var nowe in kursy)
        {
            var obecne = zBazy.FirstOrDefault(e => e.CurrencyCode == nowe.Waluta);
            if (obecne != null)
            {
                obecne.BuyRate = nowe.KursBuy;
                obecne.SellRate = nowe.KursSell;
            }
            else
            {
                db.ExchangeRates.Add(new ExchangeRate
                {
                    CurrencyCode = nowe.Waluta,
                    BuyRate = nowe.KursBuy,
                    SellRate = nowe.KursSell
                });
            }
        }

        return await db.SaveChangesAsync() > 0;
    }
    public static async Task<List<OutZysk>> PobierzZysk(Sesja db)
    {
        return await db.BankProfits
            .GroupBy(p => p.Reason)
            .Select(g => new OutZysk(
                g.Key,
                g.Sum(x => x.Amount)
            ))
            .ToListAsync();
    }
}