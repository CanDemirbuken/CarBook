using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudsByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudsByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var tagClouds = await _tagCloudRepository.GetTagCloudsByBlogIdAsync(request.BlogId);
            return tagClouds.Select(tc => new GetTagCloudsByBlogIdQueryResult
            {
                TagCloudID = tc.TagCloudID,
                Title = tc.Title,
                BlogID = tc.BlogID
            }).ToList();
        }
    }
}
