using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBankAPI.DB;
using MiniBankAPI.Models;
using MiniBankAPI.Interfaces;

namespace MiniBankAPI.Services;

public static class Konto
{
    public static async Task<IResult> Add(
        [FromHeader(Name = "X-User-Id")] int idUser,
        [FromBody] InAdd data,
        Sesja db
    )
    {
        List<string> dozwoloneWaluty = [ "PLN", "USD", "EUR", "GBP" ];
        
        if (!dozwoloneWaluty.Contains(data.Waluta.ToUpper()))
        {
            return Results.BadRequest(new { blad = "Nieobslugiwana waluta" });
        }

        var noweKonto = new Account
        {
            UserId = idUser,
            CurrencyCode = data.Waluta.ToUpper(),
            Balance = 0
        };

        await DB.Konto.DodajKonto(db, noweKonto);

        var wynik = new OutAdd(noweKonto.Id, noweKonto.UserId, noweKonto.CurrencyCode);

        return Results.Created($"/api/konta/{wynik.IdKonta}", wynik);
    }

    public static async Task<IResult> ListPosiadanych(
        [FromHeader(Name = "X-User-Id")] int idUser,
        Sesja db
    )
    {
        
        return Results.Ok(await DB.Konto.PobierzListe(db, idUser));
    }

    public static async Task<IResult> IdKonta(
        [FromHeader(Name = "X-User-Id")] int idUser,
        int id_konta,
        Sesja db
    )
    {
        bool owner = await DB.Wspolne.SprawdzWlasnosc(db, idUser, id_konta);
        
        if (!owner)
        {
            return Results.NotFound();
        }

        var kontoDb = await DB.Konto.PobierzSzczegoly(db, id_konta);

        if (kontoDb == null)
        {
            return Results.NotFound();
        }

        var wynik = new OutIdKonta(
            kontoDb.Id, 
            kontoDb.UserId, 
            kontoDb.CurrencyCode, 
            kontoDb.Balance
        );

        return Results.Ok(wynik);
    }
}