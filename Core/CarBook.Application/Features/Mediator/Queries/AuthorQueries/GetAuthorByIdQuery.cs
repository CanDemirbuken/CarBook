using CarBook.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdQueryResult>
    {
        public int AuthorID { get; set; }

        public GetAuthorByIdQuery(int authorID)
        {
            AuthorID = authorID;
        }
    }
}
