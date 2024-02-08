using Microsoft.AspNetCore.Mvc;
using NLW_Auction.API.Entities;
using NLW_Auction.API.UseCases.Auctions.GetCurrent;

namespace NLW_Auction.API.Controllers;

public class AuctionController : NLW_AuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        if(result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }
}
