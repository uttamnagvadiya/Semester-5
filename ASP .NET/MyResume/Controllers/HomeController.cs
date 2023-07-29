using Microsoft.AspNetCore.Mvc;
using MyResume.Models;
using System.Diagnostics;

namespace MyResume.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
        public IActionResult Resume()
        {
            ViewBag.Title = "Resume";
            return View();
        }
        public IActionResult Portfolio()
        {
            ViewBag.Title = "Portfolio";
            return View();
        }
        public IActionResult Services()
        {
            ViewBag.Title = "Services";
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }
        public IActionResult PortfolioDetails()
        {
            return View();
        }

    }
}