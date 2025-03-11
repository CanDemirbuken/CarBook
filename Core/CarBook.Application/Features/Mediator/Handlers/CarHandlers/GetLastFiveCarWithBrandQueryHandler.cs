using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetLastFiveCarWithBrandQueryHandler : IRequestHandler<GetLastFiveCarWithBrandQuery, List<GetLastFiveCarWithBrandQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetLastFiveCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastFiveCarWithBrandQueryResult>> Handle(GetLastFiveCarWithBrandQuery request, CancellationToken cancellationToken)
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
