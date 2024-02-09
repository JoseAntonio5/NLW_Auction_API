using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLW_Auction.API.Contracts;

namespace NLW_Auction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _repository;

    public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64toString(token);

            var userExist = _repository.ExistUserWithEmail(email);

            if (userExist == false)
            {
                context.Result = new UnauthorizedObjectResult("The email is not valid.");
            }
        } catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var auth = context.Request.Headers.Authorization.ToString();

        if(string.IsNullOrEmpty(auth))
        {
            throw new Exception("Token is missing.");
        }

        return auth["Bearer ".Length..];
    }

    // convert the bearer token (base64) to string
    private string FromBase64toString(string tokenBase64)
    {
        var data = Convert.FromBase64String(tokenBase64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
