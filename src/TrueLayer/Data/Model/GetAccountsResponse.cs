using System;

namespace TrueLayer.Data.Model;

public record GetAccountsResponse
{
    public DataAccount[] Results { get; init; } = Array.Empty<DataAccount>();
}

public record DataAccount
{
    public string UpdateTimestamp { get; init; } = string.Empty;
    public string AccountId { get; init; } = string.Empty;
    public string AccountType { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string Currency { get; init; } = string.Empty;
    public DataAccountNumber AccountNumber { get; init; } = new();
    public Provider Provider { get; init; } = new();
}

public record DataAccountNumber
{
    public string Iban { get; init; } = string.Empty;
    public string Number { get; init; } = string.Empty;
    public string SortCode { get; init; } = string.Empty;
    public string SwiftBic { get; init; } = string.Empty;
}

public record Provider
{
    public string ProviderId { get; init; } = string.Empty;
}
