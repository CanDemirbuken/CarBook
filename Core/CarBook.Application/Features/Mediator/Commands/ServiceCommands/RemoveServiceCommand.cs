using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand : IRequest
    {
        public int ServiceID { get; set; }

        public RemoveServiceCommand(int serviceID)
        {
            ServiceID = serviceID;
        }
    }
}
