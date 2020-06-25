using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ERestaurant.DAO.Model
{
    public class LoginController : Controller
    {
        private readonly MyContext _db;

        public LoginController(MyContext dbContex)
        {
            _db = dbContex;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Denied()
        {
            return Content("您没有权限访问该页面，请联系管理员！");
        }

        public IActionResult Change()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string user, string password)
        {
            var model = _db.Accounts.FirstOrDefault(x => x.Name == user && x.Password == password);
            if (model == null)
            {
                return Content("0");
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, model.Name));
            identity.AddClaim(new Claim("LoginId", model.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, model.RoleId.ToString()));
            HttpContext.SignInAsync(new ClaimsPrincipal(identity));
            return Content(model.RoleId.ToString());
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Login/Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Register(string user, string password, string address, string phone)
        {
            try
            {
                var model = new Account()
                {
                    Name = user,
                    RoleId = 2,
                    Password = password,
                    Address = address,
                    Phone = phone,
                    CreateTime = DateTime.Now
                };

                _db.Accounts.Add(model);
                _db.SaveChanges();

                return Content("1");
            }
            catch
            {
                return Content("0");
            }
        }

        [HttpPost]
        public IActionResult ChangePassword(string password, string newPassword)
        {
            var userIdStr = User.Claims.SingleOrDefault(s => s.Type == "LoginId").Value;
            int.TryParse(userIdStr, out int userId);


            var user = _db.Accounts.FirstOrDefault(x => x.Id == userId);
            if (user == null || user.Password != password)
                return Content("0");

            user.Password = newPassword;
            _db.SaveChanges();

            return Content("1");
        }
    }
}