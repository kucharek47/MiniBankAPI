namespace MiniBankAPI.Endpoints;

public static class Diagnostyka
{
    public static void map_diag_endpoints(this WebApplication app)
    {
        var diagGrupa = app.MapGroup("/api/diag");
        
        // cel: sprawdzenie stanu serwera za pomoca wbudowanej funkcji
        diagGrupa.MapGet("/health", MiniBankAPI.Services.Diagnostyka.Health);
    }
}