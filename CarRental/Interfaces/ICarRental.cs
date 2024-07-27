namespace CarRental.Interfaces
{
    public interface ICarRental
    {
        decimal CalculatePrice(int daysRented);
        decimal CalculateLateFee(int extraDays);
        int LoyaltyPoints { get; }

    }
}
