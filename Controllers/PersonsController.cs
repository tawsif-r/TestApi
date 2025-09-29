using Microsoft.AspNetCore.Mvc;
using TestApi.Data;
using TestApi.Models.Entities;


namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PersonsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var allPersons = dbContext.Persons.ToList();
            return Ok(allPersons);
        }

        [HttpPost]
        // IActionResult is a type or interface for CreatePerson
        // [FromBody] is an attribute and person is just an argument that will save the Person object
        // 
        public IActionResult CreatePerson([FromBody] Person person)
        {
            try
            {
                dbContext.Add(person);
                return Ok(new
                {
                    Message = "User created successfully",
                    Data = person
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Message= $"Something went wrong {e}"
                });
            }

            
        }

    }

}