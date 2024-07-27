namespace CarRental.Models
{
    public class RentalRequest
    {
        public int CustomerId { get; set; }
        public List<CarRentalInfo> CarRentals { get; set; }
    }
}
