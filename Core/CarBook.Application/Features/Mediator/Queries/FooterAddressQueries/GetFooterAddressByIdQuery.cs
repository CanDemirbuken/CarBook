using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
    {
        public int FooterAddressID { get; set; }

        public GetFooterAddressByIdQuery(int footerAddressID)
        {
            FooterAddressID = footerAddressID;
        }
    }
}
