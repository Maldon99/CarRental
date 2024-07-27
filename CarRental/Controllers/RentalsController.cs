using CarRental.Interfaces;
using CarRental.Models;
using CarRental.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly ICarInventoryService _carInventoryService;

        public RentalsController(IRentalService rentalService, ICarInventoryService carInventoryService)
        {
            _rentalService = rentalService;
            _carInventoryService = carInventoryService;
        }
        
            [HttpPost("rent")]
            public async Task<IActionResult> RentCars([FromBody] RentalRequest rentalRequest)
            {
                decimal totalCost = 0;
                int totalLoyaltyPoints = 0;

                foreach (var carRental in rentalRequest.CarRentals)
                {
                    var car = await _carInventoryService.GetCarAsync(carRental.CarId);
                    if (car == null)
                    {
                        return NotFound($"Car with ID {carRental.CarId} not found.");
                    }

                    var price = _rentalService.CalculateRentalPrice(car.Type, carRental.DaysRented);
                    var loyaltyPoints = _rentalService.GetLoyaltyPoints(car.Type);

                    totalCost += price;
                    totalLoyaltyPoints += loyaltyPoints;

                    // Save each rental to the database (omitted for simplicity)
                    // Update customer loyalty points (omitted for simplicity)
                }

            return Ok(new ResponseRentCars()
            {   Success=true,
                TotalCost = totalCost,
                TotalLoyaltyPoints = totalLoyaltyPoints
            });

            }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnCar([FromBody] Rental rental)
        {
            var car = await _carInventoryService.GetCarAsync(rental.CarId);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            var lateFee = _rentalService.CalculateLateFee(car.Type, rental.DaysReturnedLate);
            // Update rental in the database with return information (omitted for simplicity)

            return Ok(new ResponseReturnCar()
            {
                Success = true,
                Rental = rental,
                LateFee = lateFee
            });
        }

        [HttpGet("getCars")]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carInventoryService.GetAllCarsAsync();
            if (cars == null || cars.Count()==0)
            {
                return NotFound("Cars not found.");
            }            

            return Ok(new ResponseGetCars()
            {
                Success = true,
                Cars = cars
            });
        }

        [HttpPost("createCar")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            var oldcar = await _carInventoryService.GetCarAsync(car.Id);
            if (oldcar != null)
            {
                return NotFound("Car already exist");
            }
            var newcar =  await _carInventoryService.CreateCarAsync(car);

            return Ok(new ResponseCreateCar()
            {
                Success=true,
                Car = newcar 
            });

        }

        [HttpPost("deleteCar")]
        public async Task<IActionResult> DeleteCar([FromBody] Car car)
        {
            var oldcar = await _carInventoryService.GetCarAsync(car.Id);
            if (oldcar == null)
            {
                return NotFound("Car no exist");
            }
            var result = await _carInventoryService.DeleteCarAsync(car);

            return Ok(new { success = result });
        }

 

    }

}
