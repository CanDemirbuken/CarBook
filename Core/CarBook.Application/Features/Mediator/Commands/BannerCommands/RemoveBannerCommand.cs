using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BannerCommands
{
    public class RemoveBannerCommand : IRequest
    {
        public int BannerID { get; set; }

        public RemoveBannerCommand(int bannerID)
        {
            BannerID = bannerID;
        }
    }
}
