namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public int CategoryID { get; set; }

        public RemoveCategoryCommand(int categoryID)
        {
            CategoryID = categoryID;
        }
    }
}
