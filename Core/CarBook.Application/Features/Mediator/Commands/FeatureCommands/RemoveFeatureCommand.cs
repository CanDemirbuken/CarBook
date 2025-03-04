using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveFeatureCommand : IRequest
    {
        public int FeatureID { get; set; }

        public RemoveFeatureCommand(int featureID)
        {
            FeatureID = featureID;
        }
    }
}
