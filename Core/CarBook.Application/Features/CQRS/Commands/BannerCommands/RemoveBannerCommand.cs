namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int BannerID { get; set; }

        public RemoveBannerCommand(int bannerID)
        {
            BannerID = bannerID;
        }
    }
}
