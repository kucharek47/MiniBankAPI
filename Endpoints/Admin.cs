namespace MiniBankAPI.Endpoints;
using MiniBankAPI.Services.Admin;
public static class Admin
{
    public static void map_admin_endpoints(this WebApplication app)
    {
        var adminGrupa = app.MapGroup("/api/admin");
        
        // cel: akutalizacje kursow
        // in: [{waluta, cena},]
        // out: [{waluta, cena_kup, cena_sprzedaj},]
        // werfik: naglowek X-Api-Key
        // dodatek: cene zmien na +5% na kup na sprzedaj -5% i sprawdz czy cena w porpwaniu do starej nie rozni sie wiecej niz 20%
        adminGrupa.MapPost("set_kurs", SetKurs);
        
        // cel wyswietlenia aktualnego zysk banku
        // out int
        // werfik: naglowek X-Api-Key
        adminGrupa.MapGet("zysk", Zysk);
        
    }
}