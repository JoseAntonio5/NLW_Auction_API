using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.UseCases.Offers.GetOffer;

public class GetOfferUseCase
{
    private readonly IOfferRepository _repository;

    public GetOfferUseCase(IOfferRepository repository) => _repository = repository;

    public Offer? Execute()
    {
        return _repository.GetOffer();
    }
}
