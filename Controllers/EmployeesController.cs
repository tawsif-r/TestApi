using Microsoft.AspNetCore.Mvc;
using TestApi.Data;

namespace TestApi.Controllers
{
    //localhost:xxxx/api/
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployes()
        {
            var allEmployes = dbContext.Employees.ToList();
            return Ok(allEmployes);
        }
    }
}