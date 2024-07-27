using CarRental.Controllers;
using CarRental.Interfaces;
using CarRental.Models.Cars;
using CarRental.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace CarRental.Test
{
    

    public class SUVCartTest
    {
        [Fact]
        public async Task GIVING_a_SUVCar_WHEN_one_day_rent_THEN_a_get_the_correct_price()
        {
            var suvCar = new SUVCar();
            var daysRented = 1;
            var expectedPrice = 150;
            var price = suvCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);
        }

        [Fact]
        public async Task GIVING_a_SUVCar_WHEN_9_days_rent_THEN_a_get_the_correct_price()
        {
            var suvCar = new SUVCar();
            var daysRented = 9;
            var expectedPrice = 1290;
            var price = suvCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);
        }

        [Fact]
        public async Task GIVING_a_SUVCar_WHEN_35_days_rent_THEN_a_get_the_correct_price()
        {
            var suvCar = new SUVCar();
            var daysRented = 35;
            var expectedPrice = 4185;
            var price = suvCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);

        }

    }
}