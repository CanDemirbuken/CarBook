using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var carPricings = await _repository.GetCarPricingWithCarsAsync();
            return carPricings.Select(carPricing => new GetCarPricingWithCarQueryResult()
            {
                CarPricingID = carPricing.CarPricingID,
                BrandName = carPricing.Car.Brand.Name,
                Model = carPricing.Car.Model,
                Amount = carPricing.Amount,
                CoverImageURL = carPricing.Car.CoverImageUrl,
                PricingName = carPricing.Pricing.Name
            }).ToList();
        }
    }
}
