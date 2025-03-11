using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ContactCommands
{
    public class RemoveContactCommand : IRequest
    {
        public int ContactID { get; set; }

        public RemoveContactCommand(int contactID)
        {
            ContactID = contactID;
        }
    }
}
