using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
    public class RemoveBrandCommand : IRequest
    {
        public int BrandID { get; set; }

        public RemoveBrandCommand(int brandID)
        {
            BrandID = brandID;
        }
    }
}
