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
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommand command)
        {
            var brand = await _mediator.Send(command);
            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand([FromBody] DeleteBrandCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById([FromBody] int id)
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

