using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommand : IRequest
    {
        public int LocationID { get; set; }

        public RemoveLocationCommand(int locationID)
        {
            LocationID = locationID;
        }
    }
}
