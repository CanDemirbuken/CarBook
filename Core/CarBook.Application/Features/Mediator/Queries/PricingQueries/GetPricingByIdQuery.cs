using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public int PricingId { get; set; }

        public GetPricingByIdQuery(int pricingId)
        {
            PricingId = pricingId;
        }
    }
}
