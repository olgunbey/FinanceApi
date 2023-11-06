using FinanceInfrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index() 
        {
            string connectionString = DbConnectionString.GetConnectionString;
            return Ok();
        }
    }
}
