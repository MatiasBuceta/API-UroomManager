using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;

namespace UroomManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Tinchito", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [Route("get/asd")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("post/{id}")]
        [HttpPost]
        public Room Test(int id, [FromBody] Room room) {

            room.Id = id;

            /*string connection =
                @"Data Source=DESKTOP-DKBV2B9\SQLEXPRESS;Initial Catalog=URmanager;Integrated Security=SSPI";

            using (var db = new SqlConnection(connection)) 
            {
                var sql = "select ID,Name from TestTable";
            }


                return sala;*/

            

            return room;

        }

        [Route("get/Test")]
        [HttpGet]
        public IEnumerable<Test> GetTest()
        {   
            string connection =
                @"Data Source=DESKTOP-DKBV2B9\SQLEXPRESS;Initial Catalog=URmanager;Integrated Security=SSPI";

            using (var db = new SqlConnection(connection))
            {
                var sql = "select ID,Name from TestTable";
                var lst = db.Query<Test>(sql);
                foreach (var oElement in lst) {
                    Console.WriteLine(oElement.Name);
                }
                return lst;
            }
            
        }

    }
}
