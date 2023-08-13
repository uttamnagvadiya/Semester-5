using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;


namespace MyProject.Areas.LOC_Country.Controllers
{
    public class LOC_CountryController : Controller
    {
        private IConfiguration Configuration;

        public LOC_CountryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [Area("LOC_Country")]
       // [Route("LOC_Country/LOC_Country/LOC_CountryList")]
        public IActionResult LOC_CountryList()
        {
            string connectionString = this.Configuration.GetConnectionString("myConnectionString");

            // SQL Connection
            
            return View();
        }

        [Area("LOC_Country")]
       // [Route("LOC_Country/LOC_Country/New_Country")]
        public IActionResult LOC_CountryAddEdit()
        {
            return View();
        }
    }
}
