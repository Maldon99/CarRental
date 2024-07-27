using CarRental.Interfaces;
using CarRental.Models.Cars;
using CarRental.Persintence;
using System.Runtime.InteropServices;

namespace CarRental.Services
{
    public class CarInventoryService : ICarInventoryService
    {
        private readonly ICarRepository _carRepository;

        public CarInventoryService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<Car> GetCarAsync(int carId)
        {
            var car = await _carRepository.GetAsync(carId);
            return car;
        }
        public async Task<List<Car>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return cars;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            var newcar = await _carRepository.AddAsync(car);
            return newcar;
        }

        public async Task<bool> DeleteCarAsync(Car car)
        {
            var oldcar = await _carRepository.DeleteAsync(car.Id);
            return oldcar;

        }
    }

}
