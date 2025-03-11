using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLastThreeBlogWithAuthorQueryHandler : IRequestHandler<GetLastThreeBlogWithAuthorQuery, List<GetLastThreeBlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLastThreeBlogWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastThreeBlogWithAuthorQueryResult>> Handle(GetLastThreeBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetLastThreeBlogWithAuthorAsync();
            return blogs.Select(x => new GetLastThreeBlogWithAuthorQueryResult
            {
                BlogID = x.BlogID,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                AuthorName = x.Author.Name,
                AuthorID = x.AuthorID,
                CategoryID = x.CategoryID
            }).ToList();
        }
    }
}
