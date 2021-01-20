using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;
using UroomManager.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UroomManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ABMController : ControllerBase
    {
        ///private TestService testService;
        private RoomService roomService;
        public ABMController()
        {
            ///testService = new TestService();
            roomService = new RoomService();
        }


        // POST api/<ABMController>
        [Route("CreateRoom")]
        [HttpPost]
        public void Create([FromBody] Room room)
        {
            ///testService.testServicePost();
            roomService.roomServicePost(room);
        }

        // PUT api/<ABMController>/5
        [Route("EditRoom/{id}")]
        [HttpPut]
        public void Edit(int id, [FromBody] Room room)
        {
            roomService.roomServicePut(id, room);
        }

        // DELETE api/<ABMController>/5
        [Route("DeleteRoom/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            roomService.roomServiceDelete(id);
        }
    }
}
