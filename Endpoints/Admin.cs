namespace MiniBankAPI.Endpoints;

public static class Admin
{
    public static void map_admin_endpoints(this WebApplication app)
    {
        var adminGrupa = app.MapGroup("/api/admin");
        
        // cel: akutalizacje kursow
        // in: [{waluta, cena},]
        // out: [{waluta, cena_kup, cena_sprzedaj},]
        // werfik: naglowek X-User-Id
        // dodatek: cene zmien na +5% na kup na sprzedaj -5% i sprawdz czy cena w porpwaniu do starej nie rozni sie wiecej niz 20%
        adminGrupa.MapPost("set_kurs", MiniBankAPI.Services.Admin.SetKurs);
        
        // cel wyswietlenia aktualnego zysk banku
        // out int
        // werfik: naglowek X-User-Id
        adminGrupa.MapGet("zysk", MiniBankAPI.Services.Admin.Zysk);
        
    }
}