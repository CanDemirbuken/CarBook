using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommand : IRequest
    {
        public int TagCloudId { get; set; }

        public RemoveTagCloudCommand(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }
    }
}
