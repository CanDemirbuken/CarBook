using CarBook.Application.Features.Mediator.Results.AboutResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutByIdQuery : IRequest<GetAboutByIdQueryResult>
    {
        public int AboutID { get; set; }

        public GetAboutByIdQuery(int aboutID)
        {
            AboutID = aboutID;
        }
    }
}
