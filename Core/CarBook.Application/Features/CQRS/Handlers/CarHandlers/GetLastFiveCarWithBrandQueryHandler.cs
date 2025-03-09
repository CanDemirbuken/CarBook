using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLastFiveCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLastFiveCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastFiveCarWithBrandQueryResult>> Handle()
        {
            var cars = await _repository.GetLastFiveCarsWithBrandsAsync();
            return cars.Select(car => new GetLastFiveCarWithBrandQueryResult
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
