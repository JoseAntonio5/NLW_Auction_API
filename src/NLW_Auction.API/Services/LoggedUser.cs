using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;

    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) 
    {
        _httpContextAccessor = httpContext;
        _repository = repository;
    }

    public User User()
    {
        var token = TokenOnRequest();
        var email = FromBase64toString(token);

        return _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var auth = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return auth["Bearer ".Length..];
    }

    private string FromBase64toString(string tokenBase64)
    {
        var data = Convert.FromBase64String(tokenBase64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
