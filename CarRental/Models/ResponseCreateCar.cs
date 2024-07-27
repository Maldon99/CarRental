using CarRental.Models.Cars;

namespace CarRental.Models
{
    public class ResponseCreateCar
    {
        public bool Success { get;  set; }
        public Car Car { get;  set; }
    }
}
