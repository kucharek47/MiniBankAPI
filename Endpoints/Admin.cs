namespace MiniBankAPI.Endpoints;

public static class Admin
{
    public static void map_konta_endpoints(this WebApplication app)
    {
        var finanse_grupa = app.MapGroup("/api/finanse");

}