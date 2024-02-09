using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Contracts;

public interface IOfferRepository
{
    void CreateOffer(Offer offer);
}
