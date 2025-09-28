using CQRSMediaTr.Features.Beer.Commands.Adding;
using CQRSMediaTr.Features.Beer.Commands.DeleteBeerCommand;
using CQRSMediaTr.Features.Beer.Commands.Updating;
using CQRSMediaTr.Features.Beer.Queries.GetBeerByIdQuery;
using CQRSMediaTr.Features.Beer.Queries.GetBeersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediaTr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBeer([FromBody] AddBeerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBeer([FromBody] UpdateBeerCommand command)
        {
            var Beer = await _mediator.Send(command);
            return Ok(Beer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer([FromBody] DeleteBeerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeerById([FromBody] int id)
        {
            var query = new GetBeerByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBeers()
        {
            var query = new GetBeersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
