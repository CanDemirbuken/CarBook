using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.FooterAddressID);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID = footerAddress.FooterAddressID,
                Description = footerAddress.Description,
                Address = footerAddress.Address,
                Phone = footerAddress.Phone,
                Email = footerAddress.Email
            };
        }
    }
}
