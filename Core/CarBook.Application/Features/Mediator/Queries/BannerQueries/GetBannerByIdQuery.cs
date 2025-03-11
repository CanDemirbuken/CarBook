using CarBook.Application.Features.Mediator.Results.BannerResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetBannerByIdQuery : IRequest<GetBannerByIdQueryResult>
    {
        public int BannerId { get; set; }

        public GetBannerByIdQuery(int bannerId)
        {
            BannerId = bannerId;
        }
    }
}
