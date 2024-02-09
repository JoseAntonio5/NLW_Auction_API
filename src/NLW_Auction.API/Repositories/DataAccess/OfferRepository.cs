using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly NLW_AuctionDbContext _dbContext;
    public OfferRepository(NLW_AuctionDbContext dbContext) => _dbContext = dbContext;

    public void CreateOffer(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
