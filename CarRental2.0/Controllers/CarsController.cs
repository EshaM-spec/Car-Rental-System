
using Microsoft.AspNetCore.Mvc;
using CarRental2._0.Models;

namespace CarRental2._0.Controllers
{
    public class CarsController : Controller
    {
        static List<Car> availableCars = new List<Car> {
            new Car{Id=1, CarName="Alto",PricePerDay=3000},
            new Car{Id=2, CarName="Corolla",PricePerDay=6000},
            new Car{Id=3, CarName="Civic",PricePerDay=8000}
        };
        static List<Car> bookedCars = new List<Car>();
        public ViewResult Index()
        {
            return View(availableCars);
        }
        [HttpPost]
        public IActionResult BookCar(int id)
        {
            Car c = availableCars.Find(c => c.Id == id);
            if(c != null)
            {
                availableCars.Remove(c);
                bookedCars.Add(c);
                
            }
            return RedirectToAction("Booked");

        }
        public ViewResult Booked()
        {

            return View(bookedCars);
        }
    }
}
