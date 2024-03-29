﻿using Microsoft.AspNetCore.Mvc;
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

        // POST api/<ReservationController>
        [Route("CreateReservation")]
        [HttpPost]
        public void CreateReservationPost([FromBody] Reservation reservation)
        {
            reservationService.reservationServicePost(reservation);
        }

        // DELETE api/<ReservationController>/5
        [Route("DeleteReservation/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            reservationService.reservationServiceDelete(id);
        }
    }
}
