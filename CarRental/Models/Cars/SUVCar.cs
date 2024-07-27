using CarRental.Interfaces;

namespace CarRental.Models.Cars
{
    public class SUVCar : ICarRental
    {
        private const decimal BasePrice = 150m;

        public int LoyaltyPoints => 3;

        public decimal CalculatePrice(int daysRented)
        {
            if (daysRented <= 7)
            {
                return BasePrice * daysRented;
            }
            else if (daysRented <= 30)
            {
                return BasePrice * 7 + BasePrice * 0.8m * (daysRented - 7);
            }   
            else
            {
                return BasePrice * 7 + BasePrice * 0.8m * 23 + BasePrice * 0.5m * (daysRented - 30);
            }
        }

        public decimal CalculateLateFee(int extraDays)
        {
            return (BasePrice + BasePrice * 0.6m) * extraDays;
        }
    }
}
