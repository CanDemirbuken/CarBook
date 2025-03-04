using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var contact = await _repository.GetByIdAsync(command.ContactID);
            contact.Name = command.Name;
            contact.Email = command.Email;
            contact.Subject = command.Subject;
            contact.Message = command.Message;
            contact.SendDate = command.SendDate;

            await _repository.UpdateAsync(contact);
        }
    }
}
