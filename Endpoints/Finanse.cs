using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace MiniBankAPI.Endpoints;

public static class Finanse
{
    public static void map_finanse_endpoints(this WebApplication app)
    {
        var finanseGrupa = app.MapGroup("/api/finanse");

        // cel: wykonanie przelu z konta na konto
        // in: id_konta, kwota, nr_tranzacji_losowy
        // out: id_tranzakcji
        // werfik: naglowek X-User-Id
        // dodatek: sprawdzic timestamp
        finanseGrupa.MapPost("/przelew", MiniBankAPI.Services.Finanse.Przelew);
        
        // cel: przewalutowanie srodkow na sub konta
        // in :id_konta id_konta_odbiorczego kwota, nr_tranzacji_losowy
        // out id_tranzacji
        // werfik:  naglowek X-User-Id
        // dodatek: sprawdzanie istnienia i posiadania obu kont i posiadania wystraczajacych srodow
        finanseGrupa.MapPost("wymiana_walut", MiniBankAPI.Services.Finanse.WymianaWalut);
        
        // cel: lista aktualnych kursow kupno/sprzedaz
        // out: [[waluta, cena_kupna, cena_sprzedazy]]
        //werfik: naglowek X-User-Id
        finanseGrupa.MapGet("kursy", MiniBankAPI.Services.Finanse.Kursy);
    }
}