using Microsoft.EntityFrameworkCore;
using MiniBankAPI.DB;

namespace MiniBankAPI.DB;

public static class Wspolne
{
    public static async Task<bool> SprawdzWlasnosc(Sesja db, int idUzytkownika, int idKonta)
    {
        return await db.Accounts.AnyAsync(k => k.Id == idKonta && k.UserId == idUzytkownika);
    }
}