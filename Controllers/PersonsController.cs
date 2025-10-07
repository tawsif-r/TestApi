using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models.Entities;


namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<PersonsController> logger;
        public PersonsController(ApplicationDbContext dbContext, ILogger<PersonsController> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        //=======================
        // GET METHOD
        //=======================
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var allPersons = dbContext.Persons.ToList();
            return Ok(allPersons);
        }
        //========================
        // CREATE METHOD POST
        //========================
        [HttpPost]
        // IActionResult is a type return for the controller method
        // FromBody tells ASP.NET Core to read the value of the person parameter from the body of the HTTP request,
        // not from URL, query or form data
        // The request body is expected to be in JSON format (by default), which the framework automatically deserializes into a Person object.
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            try
            {
                dbContext.Add(person);
                await dbContext.SaveChangesAsync();
                return Ok(new
                {
                    Message = "User created successfully",
                    Data = person
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while creating a person with name: {person.Name}");
                return StatusCode(500, new
                {
                    Message = "An unexpected error occured while creating the person"
                });

            }


        }
        //============================
        //Delete method
        //============================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            try
            {
                var person = await dbContext.Persons.FindAsync(id);
                if (person == null)
                {
                    logger.LogWarning($"Delete attempted for non-existant person with id : {id}");
                    return NotFound(new { Message = "Person Not found" });
                }

                // remove from database
                dbContext.Persons.Remove(person);
                await dbContext.SaveChangesAsync();

                logger.LogInformation($"Person with Id {id} deleted successfully");
                return Ok(new { Message = "Person deleted successfully", DeletedId = id });

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while deleting person with ID: {id}");
                return StatusCode(500, new { Message = "An error occured while deleting the person" });
            }
        }

        //========================
        //PUT
        //========================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] Person updatedPerson)
        //===============parameters============================================================
        // id --> guid that will be passed throught the url
        // [FromBody] --> Take the data from the body
        // Person updatedPerson --> the updated the verson the the variable that will hold a person object?
        //=====================================================================================
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid data provided", Errors = ModelState });
            }
            try
            {
                if (updatedPerson.id != id)
                {
                    logger.LogWarning($"Id mismatch: URL id:{id} don't match the id in the body: {updatedPerson.id}");
                    return BadRequest(new { Message = "Person Id in the URL does Not match the id in request body." });
                }
                // check if the person exists
                var existingPerson = await dbContext.Persons.FindAsync(id);
                if (existingPerson == null)
                {
                    logger.LogWarning($"Update attempted for non existing person with id: {id}");
                    return NotFound(new { Message = "Person Not found" });
                }
                // ---- update the actual data---
                dbContext.Entry(existingPerson).CurrentValues.SetValues(updatedPerson);

                await dbContext.SaveChangesAsync();

                logger.LogInformation($"Person with ID: {id} updated successfully");
                return Ok(new { Message = "Person updated successfully", Data = existingPerson });
            }
            catch (Exception ex)
            {
                logger.LogError(ex,$"Error occurred while updating person with ID: {id}");
                return StatusCode(500, new { Message = "An error Occurred while updating the person" });
            }

        }

    }

}