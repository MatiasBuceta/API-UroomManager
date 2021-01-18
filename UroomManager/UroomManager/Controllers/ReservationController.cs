using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;
using UroomManager.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UroomManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private ReservationService reservationService;

        public ReservationController()
        {
            reservationService = new ReservationService();
        }

        // GET: api/<ReservationController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<ReservationController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<ReservationController>
        [Route("CreateReservation")]
        [HttpPost]
        public void CreateReservationPost([FromBody] Reservation reservation)
        {
            reservationService.reservationServicePost(reservation);
        }

        // PUT api/<ReservationController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<ReservationController>/5
        [Route("DeleteReservation/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            reservationService.reservationServiceDelete(id);
        }
    }
}
