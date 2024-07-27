namespace CarRental.Models
{
    public class ResponseReturnCar
    {
        public bool Success { get;   set; }
        public Rental Rental { get;   set; }
        public decimal LateFee { get;   set; }
    }
}
