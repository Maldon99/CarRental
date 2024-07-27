using CarRental.Interfaces;

namespace CarRental.Models.Cars
{
    public class SmallCar : ICarRental
    {
        private const decimal BasePrice = 50m;

        public int LoyaltyPoints => 1;

        public decimal CalculatePrice(int daysRented)
        {
            if (daysRented <= 7)
            {
                return BasePrice * daysRented;
            }
            else
            {
                return BasePrice * 7 + BasePrice * 0.6m * (daysRented - 7);
            }
        }

        public decimal CalculateLateFee(int extraDays)
        {
            return (BasePrice + BasePrice * 0.3m) * extraDays;
        }
    }
}
