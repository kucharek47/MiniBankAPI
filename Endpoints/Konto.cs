using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace MiniBankAPI.Endpoints;

public static class Konto
{
    public static void map_konta_endpoints(this WebApplication app)
    {
        var kontaGrupa = app.MapGroup("/api/konta");

        // cel: dodanie dla istniejacego uzytkownika nowego konta bankowego w odpowiedniej walucie
        // in: waluta
        // out: wiersz tablicy Account bez saldo
        // werfik: naglowek X-User-Id
        kontaGrupa.MapPost("/add", MiniBankAPI.Services.Konto.Add);

        // cel: wylistowanie wszystkich kont nalezacych do konkretnego uzytkownika
        // in: brak
        // out: [[id_konta, waluta],]
        // werfik: naglowek X-User-Id
        kontaGrupa.MapGet("/lista_posiadanych", MiniBankAPI.Services.Konto.ListPosiadanych);

        // cel: pobranie szczegolowych danych konkretnego konta gdzie tylko wlasciciel lub admin moze odczytac 
        // in: id_konta
        // out: wiersz tablicy Account
        // werfik: naglowek X-User-Id
        // dodatki: rate limiter na zapytania
        kontaGrupa.MapGet("/{id_konta}", MiniBankAPI.Services.Konto.IdKonta);
    }
}