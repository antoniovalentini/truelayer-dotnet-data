using System.Threading;
using System.Threading.Tasks;
using TrueLayer.Data.Model;

namespace TrueLayer.Data;

public interface IDataApi
{
    Task<ApiResponse<GetAccountsResponse>> GetAccounts(
        string accessToken,
        CancellationToken cancellationToken = default);

    Task<ApiResponse<GetAccountBalanceResponse>> GetAccountBalance(
        string accountId,
        string accessToken,
        CancellationToken cancellationToken = default);
}
