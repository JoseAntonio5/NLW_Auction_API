using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly NLW_AuctionDbContext _dbContext;
    public UserRepository(NLW_AuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
