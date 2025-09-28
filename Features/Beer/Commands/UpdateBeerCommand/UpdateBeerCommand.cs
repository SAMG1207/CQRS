using MediatR;

namespace CQRSMediaTr.Features.Beer.Commands.Updating
{
    public class UpdateBeerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
