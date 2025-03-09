using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsListWithBrandsAsync()
        {
            var cars = await _context.Cars.Include(x => x.Brand).ToListAsync();
            return cars;
        }

        public async Task<List<Car>> GetLastFiveCarsWithBrandsAsync()
        {
            var cars = await _context.Cars.Include(x => x.Brand).Take(5).OrderByDescending(x => x.CarID).ToListAsync();
            return cars;
        }
    }
}
