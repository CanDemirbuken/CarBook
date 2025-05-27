using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetBlogByAuthorIdAsync(request.AuthorId);
            return blogs.Select(blog => new GetBlogByAuthorIdQueryResult
            {
                BlogID = blog.BlogID,
                AuthorID = blog.AuthorID,
                AuthorName = blog.Author.Name,
                AuthorDescription = blog.Author.Description,
                AuthorImageUrl = blog.Author.ImageUrl
            }).ToList();
        }
    }
}
