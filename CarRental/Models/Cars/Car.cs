﻿namespace CarRental.Models.Cars
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public CarType Type { get; set; }
    }

}
