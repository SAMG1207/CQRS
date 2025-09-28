using MediatR;

namespace CQRSMediaTr.Features.Brand.Commands.Updating
{
    public class UpdateBrandCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
