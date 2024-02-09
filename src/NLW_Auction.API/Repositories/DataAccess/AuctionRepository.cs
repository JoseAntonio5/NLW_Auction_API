using Microsoft.EntityFrameworkCore;
using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly NLW_AuctionDbContext _dbContext;
    public AuctionRepository(NLW_AuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetAuction()
    {
        var today = DateTime.Now;

        return _dbContext
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts);
    }
}
