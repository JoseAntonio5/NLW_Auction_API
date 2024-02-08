using Microsoft.EntityFrameworkCore;
using NLW_Auction.API.Entities;
using NLW_Auction.API.Repositories;

namespace NLW_Auction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {

        var repository = new NLW_AuctionDbContext();

        var today = DateTime.Now;

        return repository
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}