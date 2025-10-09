using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models.Entities;

namespace TestApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<OfficesController> logger;

        // make constructor
        public OfficesController(ApplicationDbContext dbContext,ILogger<OfficesController> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllOffices()
        {
            var allOffices = dbContext.Offices.ToList();
            return Ok(allOffices);
        }

        //POST REQUEST
        [HttpPost]
        //Task<T> --> the asynchronous result type
        public async Task<IActionResult> CreateOffice([FromBody] Office office)
        {
            try
            {
                dbContext.Add(office);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "office successfully created", Data = office });

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while saving the office with id:{office.Id}");
                return StatusCode(500, new
                {
                    Message = "An unexpected error had occured"
                });
            }
        }
    }
}