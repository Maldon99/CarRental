namespace CarRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public int DaysRented { get; set; }
        public int DaysReturnedLate { get; set; }
    }

}
