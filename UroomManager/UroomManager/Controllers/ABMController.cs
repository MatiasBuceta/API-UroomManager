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
        private TestService testService;
        public ABMController()
        {
            testService = new TestService();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ABMController>
        [Route("CreateTest")]
        [HttpPost]
        public void Create()
        {
            testService.testServicePost();
        }

        // PUT api/<ABMController>/5
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ABMController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
