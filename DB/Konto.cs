using Microsoft.EntityFrameworkCore;
using MiniBankAPI.Models;
using MiniBankAPI.Interfaces;
namespace MiniBankAPI.DB;
public static class Konto
{
    public static async Task<Account?> PobierzSzczegoly(Sesja db, int idKonta)
    {
        return await db.Accounts
            .AsNoTracking() //przyspiesza dzieki nie rejestracji zmian w pamieci
            .FirstOrDefaultAsync(k => k.Id == idKonta);
    }

    public static async Task<Account?> DodajKonto(Sesja db, Account  konto)
    {
        var dodano = db.Accounts.Add(konto);
        var wynik = await db.SaveChangesAsync() > 0;
        return wynik ? dodano.Entity : null;
    }
    public static async Task<List<OutListPosiadanych>> PobierzListe(Sesja db, int idUser)
    {
        return await db.Accounts
            .Where(k => k.UserId == idUser)
            .Select(k => new OutListPosiadanych(k.Id,k.CurrencyCode))
            .ToListAsync();
    }
}