using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithAuthorQueryHandler : IRequestHandler<GetBlogWithAuthorQuery, List<GetBlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogWithAuthorQueryResult>> Handle(GetBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetBlogsWithAuthorAsync();
            return blogs.Select(blog => new GetBlogWithAuthorQueryResult
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                Description = blog.Description,
                AuthorDescription = blog.Author.Description,
                AuthorImageUrl = blog.Author.ImageUrl,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                AuthorID = blog.AuthorID,
                AuthorName = blog.Author.Name,
                CategoryID = blog.CategoryID,
                CategoryName = blog.Category.Name
            }).ToList();
        }
    }
}
