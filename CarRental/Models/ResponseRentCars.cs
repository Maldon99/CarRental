namespace CarRental.Models
{
    public class ResponseRentCars
    {
        public bool Success { get;  set; }
        public decimal TotalCost { get;  set; }
        public int TotalLoyaltyPoints { get;  set; }
    }
}
