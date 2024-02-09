using NLW_Auction.API.Entities;
using NLW_Auction.API.Repositories;

namespace NLW_Auction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedUser(IHttpContextAccessor httpContext) 
    {
        _httpContextAccessor = httpContext;
    }

    public User User()
    {
        var repository = new NLW_AuctionDbContext();

        var token = TokenOnRequest();
        var email = FromBase64toString(token);

        return repository.Users.First(user => user.Email.Equals(email));
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
