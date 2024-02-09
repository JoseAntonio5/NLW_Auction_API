using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetAuction();
}
