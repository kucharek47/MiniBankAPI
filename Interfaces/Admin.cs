namespace MiniBankAPI.Interfaces;

public record InSetKurs(
    string Waluta,
    decimal Kurs
);

public record DBSetKurs(
    string Waluta,
    decimal Kurs,
    decimal KursBuy,
    decimal KursSell
);

public record InZysk(
    string Waluta,
    decimal Kurs
);
public record OutZysk(
    string Typ,
    decimal Zysk
);