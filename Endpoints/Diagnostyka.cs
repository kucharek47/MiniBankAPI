namespace MiniBankAPI.Endpoints;

public static class Diagnostyka
{
    public static void map_diag_endpoints(this WebApplication app)
    {
        var diag_grupa = app.MapGroup("/api/finanse");
        
        // cel: sprawdzenie stanu serwera za pomoca wbudowanej funkcji
        diag_grupa.MapGet("/health", MiniBankAPI.Services.Diagnostyka.Health);
    }
}