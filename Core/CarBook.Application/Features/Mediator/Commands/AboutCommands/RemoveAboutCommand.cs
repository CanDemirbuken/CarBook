using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AboutCommands
{
    public class RemoveAboutCommand : IRequest
    {
        public int AboutID { get; set; }

        public RemoveAboutCommand(int aboutID)
        {
            AboutID = aboutID;
        }
    }
}
