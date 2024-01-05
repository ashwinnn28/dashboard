using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Chart.Models;

namespace Chart.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString = "Server=ASHWIN;Database=CountryPopulationDB;Integrated Security=True;";

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetCountryData()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch data from the database
                var countries = connection.Query<Country>("SELECT * FROM Country").ToList();

                return Json(countries);
            }
        }
    }
}
