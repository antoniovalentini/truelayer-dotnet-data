using System;
using System.Threading;
using System.Threading.Tasks;
using TrueLayer.Data.Model;
using TrueLayer.Extensions;

namespace TrueLayer.Data;

internal class DataApi : IDataApi
{
    private readonly IApiClient _apiClient;
    private readonly Uri _baseUri;

    public DataApi(IApiClient apiClient, TrueLayerOptions options)
    {
        _apiClient = apiClient.NotNull(nameof(apiClient));
        _baseUri = options.NotNull(nameof(options)).GetApiBaseUri().Append(DataEndpoints.Data);
    }

    public async Task<ApiResponse<GetAccountsResponse>> GetAccounts(string accessToken, CancellationToken cancellationToken = default)
    {
        accessToken.NotNullOrWhiteSpace(nameof(accessToken));

        return await _apiClient.GetAsync<GetAccountsResponse>(
            _baseUri.Append(DataEndpoints.AccountsV1),
            accessToken,
            cancellationToken: cancellationToken
        );
    }

    public async Task<ApiResponse<GetAccountBalanceResponse>> GetAccountBalance(string accountId, string accessToken, CancellationToken cancellationToken = default)
    {
        accessToken.NotNullOrWhiteSpace(nameof(accessToken));

        return await _apiClient.GetAsync<GetAccountBalanceResponse>(
            _baseUri.Append(DataEndpoints.AccountsV1).Append(accountId).Append(DataEndpoints.Balance),
            accessToken,
            cancellationToken: cancellationToken
        );
    }
}
