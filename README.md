Solution:
-Visual Studio Community 2022

-Project CarRental
	ASP.NET Core Web API (.NET 8.0)

-Project CarRental.Test
	xUnit test project


API:
The API expose the following operations: 
    Calculate the price for rental 
		-RentCars  (rent n cars)
		-ReturnCar (return a car)
	Inventory of cars 
		-GetCars (get the inventory of cars)
		-AddCar  (add a car to the inventory)
		-DeleteCar (delete a car of the inventory)

Use Swagger to test the API 

Incomplete solution:
TODO (use a real DB)
 -We use InMemoryDbContext in order to simplify the execice.
 -API GetCustomer (to get the customer loyalty points)
