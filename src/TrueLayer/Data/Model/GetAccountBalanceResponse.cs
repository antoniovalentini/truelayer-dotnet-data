using System;

namespace TrueLayer.Data.Model;

public record GetAccountBalanceResponse
{
    public DataAccountBalance[] Results { get; init; } = Array.Empty<DataAccountBalance>();
}

public record DataAccountBalance
{
    public string Currency { get; init; } = string.Empty;
    public decimal Available { get; init; }
    public decimal Current { get; init; }
    public decimal Overdraft { get; init; }
    public string UpdateTimestamp { get; init; } = string.Empty;
}
