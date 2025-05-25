using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery : IRequest<GetTagCloudByIdQueryResult>
    {
        public int TagCloudId { get; set; }
        public GetTagCloudByIdQuery(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }
    }
}
