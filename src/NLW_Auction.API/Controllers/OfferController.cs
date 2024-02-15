using Microsoft.AspNetCore.Mvc;
using NLW_Auction.API.Communication.Requests;
using NLW_Auction.API.Entities;
using NLW_Auction.API.Filters;
using NLW_Auction.API.UseCases.Offers.CreateOffer;
using NLW_Auction.API.UseCases.Offers.GetOffer;

namespace NLW_Auction.API.Controllers;

public class OfferController : NLW_AuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Offer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetOffer([FromServices] GetOfferUseCase useCase)
    {
        var result = useCase.Execute();

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

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
