using Core;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private Address _address;
        private Person _person;
        public PersonController(Address address, Person person)
        {
            _address = address;
            _person = person;
        }

        [HttpGet("address")]
        public IActionResult GetAddress()
        {
            var address = _address.GetRandomAddress();

            if (address == null)
                return NotFound();

            return Ok(address);
        }
        [HttpGet("person")]
        public IActionResult GetPerson()
        {
            var person = _person.SetRandomPerson();

            if (person == null)
                return NotFound();

            return Ok(person);
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
