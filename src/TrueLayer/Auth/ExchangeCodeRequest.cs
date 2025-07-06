namespace TrueLayer.Auth;

public record ExchangeCodeRequest
{
    /// <summary>
    /// The authorization code to exchange for an access token
    /// </summary>
    public string Code { get; init; } = string.Empty;

    /// <summary>
    /// The redirect URI used in the authorization request
    /// </summary>
    public string RedirectUri { get; init; } = string.Empty;
}
