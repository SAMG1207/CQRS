using MediatR;

namespace CQRSMediaTr.Features.Beer.Commands.Adding
{
    public class AddBeerCommand : IRequest<Domain.Beer>
    {
        public string Name {  get; set; }
        public int BrandId { get; set; }
    }
}
