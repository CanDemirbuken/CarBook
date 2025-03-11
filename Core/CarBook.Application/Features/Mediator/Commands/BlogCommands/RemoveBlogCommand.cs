using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand : IRequest
    {
        public int BlogID { get; set; }

        public RemoveBlogCommand(int blogID)
        {
            BlogID = blogID;
        }
    }
}
