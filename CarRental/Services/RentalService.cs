using CarRental.Interfaces;
using CarRental.Models;
using CarRental.Models.Cars;

namespace CarRental.Services
{
    public class RentalService:IRentalService
    {
        public RentalService()
        {
        }

        private readonly Dictionary<CarType, ICarRental> _cars =
            new Dictionary<CarType, ICarRental>
            {
                { CarType.Premium, new PremiumCar() },
                { CarType.SUV, new SUVCar() },
                { CarType.Small, new SmallCar() }
            };
                

        public decimal CalculateRentalPrice(CarType carType, int daysRented)
        {
            if (_cars.TryGetValue(carType, out var car))
            {
                return car.CalculatePrice(daysRented);
            }

            throw new ArgumentException("Invalid car type", nameof(carType));
        }

        public decimal CalculateLateFee(CarType carType, int extraDays)
        {
            if (_cars.TryGetValue(carType, out var car))
            {
                return car.CalculateLateFee(extraDays);
            }

            throw new ArgumentException("Invalid car type", nameof(carType));
        }

        public int GetLoyaltyPoints(CarType carType)
        {
            if (_cars.TryGetValue(carType, out var car))
            {
                return car.LoyaltyPoints;
            }

            throw new ArgumentException("Invalid car type", nameof(carType));
        }


    }

}
