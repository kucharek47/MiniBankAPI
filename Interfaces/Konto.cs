namespace MiniBankAPI.Interfaces;

public record InAdd(string Waluta);

public record OutAdd(int IdKonta, int IdUzytkownika, string Waluta);

public record OutListPosiadanych(int IdKonta, string Waluta);

public record OutIdKonta(int IdKonta, int IdUzytkownika, string Waluta, decimal Saldo);