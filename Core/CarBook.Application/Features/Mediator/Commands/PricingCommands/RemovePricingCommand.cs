using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands
{
    public class RemovePricingCommand : IRequest
    {
        public int PricingID { get; set; }

        public RemovePricingCommand(int pricingID)
        {
            PricingID = pricingID;
        }
    }
}
