using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute()
    {
        return _repository.GetAuction();
    }
}