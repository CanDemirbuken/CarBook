using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
    {
        public int BlogID { get; set; }

        public GetBlogByIdQuery(int blogID)
        {
            BlogID = blogID;
        }
    }
}
