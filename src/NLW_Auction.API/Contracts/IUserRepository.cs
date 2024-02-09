using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
