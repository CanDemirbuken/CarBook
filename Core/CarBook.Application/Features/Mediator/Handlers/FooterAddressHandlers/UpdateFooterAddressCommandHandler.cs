using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.FooterAddressID);
            footerAddress.Description = request.Description;
            footerAddress.Address = request.Address;
            footerAddress.Phone = request.Phone;
            footerAddress.Email = request.Email;
            
            await _repository.UpdateAsync(footerAddress);
        }
    }
}
