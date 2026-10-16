using Microsoft.EntityFrameworkCore;
using MiniBankAPI.DB;

namespace MiniBankAPI.DB;

public static class Wspolne
{
    public static async Task<bool> SprawdzWlasnoscKonta(Sesja db, int id_uzytkownika, int id_konta)
    {
        return await db.Accounts.AnyAsync(k => k.Id == id_konta && k.UserId == id_uzytkownika);
    }
}