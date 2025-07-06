namespace TrueLayer.Auth;

public record ExchangeCodeResponse
{
    /// <summary>
    /// The access token issued by the authorization server
    /// </summary>
    public string AccessToken { get; init; } = string.Empty;

    /// <summary>
    /// The type of the access token, typically "Bearer"
    /// </summary>
    public string TokenType { get; init; } = string.Empty;

    /// <summary>
    /// The lifetime in seconds of the access token
    /// </summary>
    public string ExpiresIn { get; init; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}
