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
        // make constructor
        public OfficesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult GetAllOffices()
        {
            var allOffices = dbContext.Offices.ToList();
            return Ok(allOffices);
        }
    }
}