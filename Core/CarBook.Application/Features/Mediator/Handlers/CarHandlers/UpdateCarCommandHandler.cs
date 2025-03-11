using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(request.CarID);
            car.Fuel = request.Fuel;
            car.Transmisson = request.Transmisson;
            car.BigImageUrl = request.BigImageUrl;
            car.BrandID = request.BrandID;
            car.CoverImageUrl = request.CoverImageUrl;
            car.Km = request.Km;
            car.Luggage = request.Luggage;
            car.Model = request.Model;
            car.Seat = request.Seat;

            await _repository.UpdateAsync(car);
        }
    }
}
