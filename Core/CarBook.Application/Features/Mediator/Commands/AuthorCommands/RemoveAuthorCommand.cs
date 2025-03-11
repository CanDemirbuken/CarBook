using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands
{
    public class RemoveAuthorCommand : IRequest
    {
        public int AuthorID { get; set; }

        public RemoveAuthorCommand(int authorID)
        {
            AuthorID = authorID;
        }
    }
}
