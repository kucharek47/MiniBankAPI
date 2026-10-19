using Microsoft.AspNetCore.Mvc;
using MiniBankAPI.DB;
using MiniBankAPI.Interfaces;
namespace MiniBankAPI.Services;

public static class Admin
{
    public static async Task<IResult> SetKurs(
        [FromHeader(Name = "X-Auth-Token")] int idUser,
        [FromBody] List<InSetKurs> data,
        Sesja db
    )
    {
        //TODO sprawdzenie czy idUser sie zgadza
        
        List<DBSetKurs> toSet = [];

        foreach (var x in data)
        {
            decimal kursBuy = Math.Round(x.Kurs * 1.05m, 6);
            decimal kursSell = Math.Round(x.Kurs * 0.95m, 6);
            toSet.Add(new DBSetKurs(x.Waluta, x.Kurs, kursBuy, kursSell));
        }
        await DB.Admin.ZapisKursow(db, toSet);
        return Results.Ok();
    }

    public static async Task<IResult> Zysk(
        [FromHeader(Name = "X-Auth-Token")] int idUser,
        [FromBody] InZysk data,
        Sesja db)
    {
        //TODO sprawdzenie czy idUser sie zgadza
        
        return Results.Ok();
    }
}