namespace CarBook.Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveBrandCommand
    {
        public int BrandID { get; set; }

        public RemoveBrandCommand(int brandID)
        {
            BrandID = brandID;
        }
    }
}
