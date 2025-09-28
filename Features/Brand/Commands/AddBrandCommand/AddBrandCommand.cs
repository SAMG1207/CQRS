using MediatR;

namespace CQRSMediaTr.Features.Brand.Commands.Adding
{
    public class AddBrandCommand : IRequest<Domain.Brand>
    {
        public string Name { get; set; }
    }
}
