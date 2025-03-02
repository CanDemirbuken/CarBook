using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.CarID);
            car.Fuel = command.Fuel;
            car.Transmisson = command.Transmisson;
            car.BigImageUrl = command.BigImageUrl;
            car.BrandID = command.BrandID;
            car.CoverImageUrl = command.CoverImageUrl;
            car.Km = command.Km;
            car.Luggage = command.Luggage;
            car.Model = command.Model;
            car.Seat = command.Seat;

            await _repository.UpdateAsync(car);
        }
    }
}
