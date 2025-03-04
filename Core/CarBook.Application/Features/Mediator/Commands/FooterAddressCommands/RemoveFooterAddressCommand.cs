using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand : IRequest
    {
        public int FooterAddressID { get; set; }

        public RemoveFooterAddressCommand(int footerAddressID)
        {
            FooterAddressID = footerAddressID;
        }
    }
}
