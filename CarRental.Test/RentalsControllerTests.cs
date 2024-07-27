using CarRental.Controllers;
using CarRental.Interfaces;
using CarRental.Models;
using CarRental.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace CarRental.Test
{
    

    public class CarRentalControllerTests
    {
        private readonly Mock<ICarInventoryService> _mockCarInventoryService;
        private readonly Mock<IRentalService> _mockRentalService;
        private readonly RentalsController _controller;

        public CarRentalControllerTests()
        {
            _mockCarInventoryService = new Mock<ICarInventoryService>();
            _mockRentalService = new Mock<IRentalService>();
            _controller = new RentalsController(_mockRentalService.Object, _mockCarInventoryService.Object);
        }

        [Fact]
        public async Task GIVEN_a_RentalsController_WHEN_call_RentCars_action_THEN_I_get_OkObjectResult()
        {
            var mockCarInventoryService = new Mock<ICarInventoryService>();
            var mockRentalService = new Mock<IRentalService>();
            var controller = new RentalsController(mockRentalService.Object, mockCarInventoryService.Object);
            var rentalRequest = new RentalRequest
            {
                CustomerId = 1,
                CarRentals = new List<CarRentalInfo>
                {
                    new CarRentalInfo { CarId = 1, DaysRented = 3 },
                    new CarRentalInfo { CarId = 2, DaysRented = 1 }
                }
            };

            var car1 = new Car { Id = 1, Type = CarType.Premium };
            var car2 = new Car { Id = 2, Type = CarType.SUV };
            mockCarInventoryService.Setup(service => service.GetCarAsync(1)).ReturnsAsync(car1);
            mockCarInventoryService.Setup(service => service.GetCarAsync(2)).ReturnsAsync(car2);
            mockRentalService.Setup(service => service.CalculateRentalPrice(CarType.Premium, 3)).Returns(900m);
            mockRentalService.Setup(service => service.CalculateRentalPrice(CarType.SUV, 1)).Returns(150m);
            mockRentalService.Setup(service => service.GetLoyaltyPoints(CarType.Premium)).Returns(5);
            mockRentalService.Setup(service => service.GetLoyaltyPoints(CarType.SUV)).Returns(3);

            var result = await controller.RentCars(rentalRequest) as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var response = result.Value as ResponseRentCars; 
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(1050m, response.TotalCost); //900 + 150
            Assert.Equal(8, response.TotalLoyaltyPoints);  //5 + 3 

        }

        [Fact]
        public async Task GIVEN_a_RentalsController_WHEN_call_ReturnCar_action_THEN_I_get_OkObjectResult()
        {
            var mockCarInventoryService = new Mock<ICarInventoryService>();
            var mockRentalService = new Mock<IRentalService>();
            var controller = new RentalsController(mockRentalService.Object, mockCarInventoryService.Object);
            var rental = new Rental
            {
                CustomerId = 1,
                CarId = 1,
                StartDate = DateTime.Now.AddDays(-2),
                DaysRented = 1, 
                DaysReturnedLate = 1 
            };
            var car1 = new Car { Id = 1, Type = CarType.Premium };
            mockCarInventoryService.Setup(service => service.GetCarAsync(1)).ReturnsAsync(car1);
            mockRentalService.Setup(service => service.CalculateLateFee(CarType.Premium, rental.DaysReturnedLate)).Returns(360m); 

            var result = await controller.ReturnCar(rental) as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var response = result.Value as ResponseReturnCar;
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(360m, response.LateFee); //300 + 60

        }

    }
}