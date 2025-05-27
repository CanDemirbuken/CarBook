using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByAuthorIdQuery : IRequest<List<GetBlogByAuthorIdQueryResult>>
    {
        public int AuthorId { get; set; }
        public GetBlogByAuthorIdQuery(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
