
using Microsoft.AspNetCore.Mvc;
using ERestaurant.DAO;

namespace ERestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _db;

        public HomeController(MyContext dbContex)
        {
            _db = dbContex;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
