using CarRental.Controllers;
using CarRental.Interfaces;
using CarRental.Models.Cars;
using CarRental.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace CarRental.Test
{
    

    public class PremiumCartTest
    {
        [Fact]
        public async Task GIVING_a_PremiumCar_WHEN_one_day_rent_THEN_a_get_the_correct_price()
        {
            var premiumCar = new PremiumCar();
            var daysRented = 1;
            var expectedPrice = 300;
            var price = premiumCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);

        }

        [Fact]
        public async Task GIVING_a_PremiumCar_WHEN_two_days_rent_THEN_a_get_the_correct_price()
        {
            var premiumCar = new PremiumCar();
            var daysRented = 2;
            var expectedPrice = 600;
            var price = premiumCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);

        }
        [Fact]
        public async Task GIVING_a_PremiumCar_WHEN_10_days_rent_THEN_a_get_the_correct_price()
        {
            var premiumCar = new PremiumCar();
            var daysRented = 10;
            var expectedPrice = 3000;
            var price = premiumCar.CalculatePrice(daysRented);
            Assert.Equal(expectedPrice, price);

        }
    }
}