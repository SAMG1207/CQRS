using CQRSMediaTr.Features.Beer.Queries.GetBeersQuery;
using CQRSMediaTr.Features.Brand.Commands.Adding;
using CQRSMediaTr.Features.Brand.Commands.DeleteBrandCommand;
using CQRSMediaTr.Features.Brand.Commands.Updating;
using CQRSMediaTr.Features.Brand.Queries.GetBrandByIdQuery;
using CQRSMediaTr.Features.Brand.Queries.GetBrandsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediaTr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] AddBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var command = new DeleteBrandCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
           var query = new GetBrandByIdQuery { Id = id };
           var result = await _mediator.Send(query);
           return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var query = new GetBrandsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

