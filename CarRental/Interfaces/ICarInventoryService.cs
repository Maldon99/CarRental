using CarRental.Models.Cars;

namespace CarRental.Interfaces
{
    public interface ICarInventoryService
    {
        Task<Car> GetCarAsync(int carId);
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> CreateCarAsync(Car car);
        Task<bool> DeleteCarAsync(Car car);

    }

}
