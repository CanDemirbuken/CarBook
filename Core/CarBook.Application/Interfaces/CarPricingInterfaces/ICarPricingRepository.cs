using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingWithCarsAsync();
    }
}
