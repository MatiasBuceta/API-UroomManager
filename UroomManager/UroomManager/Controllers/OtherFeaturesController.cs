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
    public class OtherFeaturesController : ControllerBase
    {
        private ReservationService reservationService;
        private RoomService roomService;
        public OtherFeaturesController()
        {
            reservationService = new ReservationService();
            roomService = new RoomService();
        }

        ///GET: api/<ReservationController>
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
        [Route("OptimalSearch")]
        [HttpPost]
        public IEnumerable<Room> GetOptimalReservationPost([FromBody] OptReservation optreservation)
        {

            Room room = new Room();
            room.Capacity = optreservation.Capacity;
            room.Projector = optreservation.Projector;
            room.Blackboard = optreservation.Blackboard;
            room.Internet = optreservation.Internet;
            string date = optreservation.ReservationDate;
            string starttime = optreservation.ReservationStartTime;
            string endtime = optreservation.ReservationEndTime;

            List<Room> roomlst= reservationService.optimalReservations(room, date, starttime, endtime);

            return roomlst;
        }

        [Route("ReservationReport")]
        [HttpPost]
        public void ReservationReportPost([FromBody] Reservation reservation)
        {
            
        }


        // PUT api/<ReservationController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<ReservationController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
