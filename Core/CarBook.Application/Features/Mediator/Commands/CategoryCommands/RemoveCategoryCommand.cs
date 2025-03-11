using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest
    {
        public int CategoryID { get; set; }

        public RemoveCategoryCommand(int categoryID)
        {
            CategoryID = categoryID;
        }
    }
}
