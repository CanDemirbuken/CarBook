using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Car
            {
                BrandID = request.BrandID,
                BigImageUrl = request.BigImageUrl,
                CoverImageUrl = request.CoverImageUrl,
                Fuel = request.Fuel,
                Km = request.Km,
                Luggage = request.Luggage,
                Model = request.Model,
                Seat = request.Seat,
                Transmisson = request.Transmisson
            });
        }
    }
}
