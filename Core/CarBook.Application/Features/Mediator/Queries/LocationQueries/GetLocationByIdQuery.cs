using CarBook.Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public int LocationId { get; set; }

        public GetLocationByIdQuery(int locationId)
        {
            LocationId = locationId;
        }
    }
}