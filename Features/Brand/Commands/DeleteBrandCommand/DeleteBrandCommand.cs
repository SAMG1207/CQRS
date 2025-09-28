using MediatR;

namespace CQRSMediaTr.Features.Brand.Commands.DeleteBrandCommand
{
    public class DeleteBrandCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
