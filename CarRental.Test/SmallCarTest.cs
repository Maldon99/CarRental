using CarRental.Controllers;
using CarRental.Interfaces;
using CarRental.Models.Cars;
using CarRental.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace CarRental.Test
{
    

    public class SmallCarTest
    {
        [Fact]
        public async Task GIVEN_a_SmallCar_WHEN_one_day_rent_THEN_a_get_the_correct_price()
        {
            var smallCar = new SmallCar();
            var daysRented = 1;
            var expectedPrice = 50;
            var price = smallCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);

        }

        [Fact]
        public async Task GIVEN_a_SmallCar_WHEN_10_days_rent_THEN_a_get_the_correct_price()
        {
            var smallCar = new SmallCar();
            var daysRented = 10;
            var expectedPrice = 440;
            var price = smallCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);

        }

       


    }
}