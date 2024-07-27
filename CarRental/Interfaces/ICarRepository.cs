using CarRental.Models.Cars;

namespace CarRental.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetAsync(int carId);
        Task<List<Car>> GetAllAsync();
        Task<Car> AddAsync(Car car);
        Task<bool> DeleteAsync(int id); 

    }
}
