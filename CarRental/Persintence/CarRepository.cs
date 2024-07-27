using CarRental.Interfaces;
using CarRental.Models.Cars;

namespace CarRental.Persintence
{
    public class CarRepository : ICarRepository
    {
        private readonly InMemoryDbContext _context;

        public CarRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public Task<Car> AddAsync(Car car)
        {
            _context.Cars.Add(car);
            return Task.FromResult(car);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var car = _context.Cars.Where(c=>c.Id==id).SingleOrDefault();
            _context.Cars.Remove(car);
            return Task.FromResult(true);
        }

        public Task<List<Car>> GetAllAsync()
        {
            var result = _context.Cars;
            return Task.FromResult(result);
        }

        public Task<Car> GetAsync(int carId)
        {
            var result = _context.Cars.Where(b => b.Id == carId).ToList().SingleOrDefault();
            return Task.FromResult(result);
        }

    }
}
