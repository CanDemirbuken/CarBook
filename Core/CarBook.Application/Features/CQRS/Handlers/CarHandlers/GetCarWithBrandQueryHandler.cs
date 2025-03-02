using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var cars = await _repository.GetCarsListWithBrandsAsync();
            return cars.Select(car => new GetCarWithBrandQueryResult
            {
                CarID = car.CarID,
                BrandID = car.BrandID,
                BrandName = car.Brand.Name,
                BigImageUrl = car.BigImageUrl,
                CoverImageUrl = car.CoverImageUrl,
                Fuel = car.Fuel,
                Km = car.Km,
                Luggage = car.Luggage,
                Model = car.Model,
                Seat = car.Seat,
                Transmisson = car.Transmisson
            }).ToList();
        }
    }
}
