using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NLW_Auction.API.Controllers;

public class OfferController : NLW_AuctionBaseController
{
    [HttpPost]
    public IActionResult CreateOffer()
    {
        return Created();
    }
}
