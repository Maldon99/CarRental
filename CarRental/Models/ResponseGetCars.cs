using CarRental.Models.Cars;

namespace CarRental.Models
{
    public class ResponseGetCars
    {
        public bool Success { get;  set; }
        public List<Car> Cars { get;  set; }
    }
}
