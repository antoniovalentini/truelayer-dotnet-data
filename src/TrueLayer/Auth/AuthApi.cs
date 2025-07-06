using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TrueLayer.Extensions;

namespace TrueLayer.Auth;

internal class AuthApi : IAuthApi
{
    private readonly IApiClient _apiClient;
    private readonly TrueLayerOptions _options;
    private readonly Uri _baseUri;

    public AuthApi(IApiClient apiClient, TrueLayerOptions options)
    {
        _apiClient = apiClient.NotNull(nameof(apiClient));
        _options = options.NotNull(nameof(options));
        _baseUri = options.GetAuthBaseUri();
    }

    /// <inheritdoc />
    public async ValueTask<ApiResponse<GetAuthTokenResponse>> GetAuthToken(GetAuthTokenRequest authTokenRequest, CancellationToken cancellationToken = default)
    {
        authTokenRequest.NotNull(nameof(authTokenRequest));

        var values = new List<KeyValuePair<string?, string?>>
        {
            new ("grant_type", "client_credentials"),
            new ("client_id", _options.ClientId),
            new ("client_secret", _options.ClientSecret),
        };

        if (authTokenRequest.IsScoped)
        {
            values.Add(new("scope", authTokenRequest.Scope));
        }

        return await _apiClient.PostAsync<GetAuthTokenResponse>(
            _baseUri.Append(AuthEndpoints.Token), new FormUrlEncodedContent(values), null, cancellationToken);
    }

    public async ValueTask<ApiResponse<ExchangeCodeResponse>> ExchangeCode(
        ExchangeCodeRequest exchangeCodeRequest,
        CancellationToken cancellationToken = default)
    {
        exchangeCodeRequest.NotNull(nameof(exchangeCodeRequest));
        exchangeCodeRequest.Code.NotEmptyOrWhiteSpace(nameof(exchangeCodeRequest.Code));
        exchangeCodeRequest.RedirectUri.NotEmptyOrWhiteSpace(nameof(exchangeCodeRequest.RedirectUri));

        var values = new List<KeyValuePair<string?, string?>>
        {
            new ("grant_type", "authorization_code"),
            new ("client_id", _options.ClientId),
            new ("client_secret", _options.ClientSecret),
            new ("redirect_uri", exchangeCodeRequest.RedirectUri),
            new ("code", exchangeCodeRequest.Code),
        };

        return await _apiClient.PostAsync<ExchangeCodeResponse>(
            _baseUri.Append(AuthEndpoints.Token),
            new FormUrlEncodedContent(values),
            null,
            cancellationToken);
    }

    public async ValueTask<ApiResponse<ExchangeCodeResponse>> RefreshToken(string refreshToken, CancellationToken cancellationToken = default)
    {
        refreshToken.NotEmptyOrWhiteSpace(nameof(refreshToken));

        var values = new List<KeyValuePair<string?, string?>>
        {
            new ("grant_type", "refresh_token"),
            new ("client_id", _options.ClientId),
            new ("client_secret", _options.ClientSecret),
            new ("refresh_token", refreshToken),
        };

        return await _apiClient.PostAsync<ExchangeCodeResponse>(
            _baseUri.Append(AuthEndpoints.Token),
            new FormUrlEncodedContent(values),
            null,
            cancellationToken);
    }
}
