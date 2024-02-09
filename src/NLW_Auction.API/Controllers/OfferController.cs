using Microsoft.AspNetCore.Mvc;
using NLW_Auction.API.Communication.Requests;
using NLW_Auction.API.Filters;
using NLW_Auction.API.UseCases.Offers.CreateOffer;

namespace NLW_Auction.API.Controllers;

public class OfferController : NLW_AuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult CreateOffer(
        [FromRoute] int itemId, 
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase
        )
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
