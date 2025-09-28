using MediatR;

namespace CQRSMediaTr.Features.Beer.Commands.DeleteBeerCommand
{
    public class DeleteBeerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
