using Microsoft.AspNetCore.Mvc;
using TestApi.Data;
using System.Linq;

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
            // var salaryEmployees = dbContext.Employees.ToList();
            // var result = salaryEmployees.Where(p => p.Salary > 1000).ToList();
            // return Ok(result);
        }
    }
}