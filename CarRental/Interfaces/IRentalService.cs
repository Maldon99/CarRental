using CarRental.Models.Cars;
using CarRental.Models;

namespace CarRental.Interfaces
{
    public interface IRentalService
    {
        decimal CalculateRentalPrice(CarType carType, int daysRented);
        decimal CalculateLateFee(CarType carType, int extraDays);
        int GetLoyaltyPoints(CarType carType);

    }
}
