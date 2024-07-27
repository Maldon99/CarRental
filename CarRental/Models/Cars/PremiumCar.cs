using CarRental.Interfaces;

namespace CarRental.Models.Cars
{
    public class PremiumCar : ICarRental
    {
        private const decimal BasePrice = 300m;

        public int LoyaltyPoints => 5;

        public decimal CalculatePrice(int daysRented)
        {
            return BasePrice * daysRented;
        }

        public decimal CalculateLateFee(int extraDays)
        {
            return (BasePrice + BasePrice * 0.2m) * extraDays;
        }
    }
}
