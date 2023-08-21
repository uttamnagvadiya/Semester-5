using Microsoft.AspNetCore.Mvc;

namespace My_Project.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    public class LOC_StateController : Controller
    {
        public IActionResult Index()
        {
            return View("LOC_StateList");
        }
    }
}
