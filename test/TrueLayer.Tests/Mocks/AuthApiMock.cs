using System.Threading;
using System.Threading.Tasks;
using TrueLayer.Auth;

namespace TrueLayer.Tests.Mocks;

public class AuthApiMock : IAuthApi
{
    private ApiResponse<GetAuthTokenResponse>? _response;

    public void SetGetAuthToken(ApiResponse<GetAuthTokenResponse> response)
    {
        _response = response;
    }

    public void ResetGetAuthToken()
    {
        _response = null;
    }

    public ValueTask<ApiResponse<GetAuthTokenResponse>> GetAuthToken(GetAuthTokenRequest authTokenRequest, CancellationToken cancellationToken = default)
    {
        return new ValueTask<ApiResponse<GetAuthTokenResponse>>(_response!);
    }

    public ValueTask<ApiResponse<ExchangeCodeResponse>> ExchangeCode(ExchangeCodeRequest exchangeCodeRequest, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }

    public ValueTask<ApiResponse<ExchangeCodeResponse>> RefreshToken(string refreshToken, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}
