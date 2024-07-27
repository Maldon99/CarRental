using CarRental.Models;
using CarRental.Models.Cars;

namespace CarRental.Persintence
{
    public class InMemoryDbContext
    {
        private readonly List<Car> _cars = new List<Car>();

        public List<Car> Cars => _cars;

        public InMemoryDbContext()
        {
            _cars= new List<Car>()
            {
                new Car { Id = 1, Make = "BMW", Model = "7", Type = CarType.Premium },
                new Car { Id = 2, Make = "Kia", Model = "Sorento", Type = CarType.SUV },
                new Car { Id = 3, Make = "Nissan", Model = "Juke", Type = CarType.SUV },
                new Car { Id = 4, Make = "Seat", Model = "Ibiza", Type = CarType.Small }
            };
        }
    }
}
