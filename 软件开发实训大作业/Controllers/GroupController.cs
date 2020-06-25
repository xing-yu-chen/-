using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERestaurant.DAO;
using ERestaurant.DAO.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERestaurant.Controllers
{
    public class GroupController : Controller
    {
        private readonly MyContext _db;
        public GroupController(MyContext dbContex)
        {
            _db = dbContex;
        }

        [Authorize(Roles = "1")]
        public IActionResult List()
        {
            return View();
        }

        public IActionResult GetGroups()
        {
            var query = _db.Groups;

            return Json(new { Status = true, Data = query.ToList(), Total = query.Count() });
        }

        public IActionResult EditGroup(int id, string name)
        {
            if (id > 0)
            {
                var model = _db.Groups.FirstOrDefault(x => x.Id == id);
                if (model == null)  return Json(new { Status = false }); 
                model.Name = name;
            }
            else
            {
                var group = new Group();
                group.Name = name;

                _db.Groups.Add(group);
            }
            _db.SaveChanges();

            return Json(new { Status = true});
        }

        public IActionResult DeleteGroup(int id)
        {
            var model = _db.Groups.FirstOrDefault(x => x.Id == id);
            if (model == null) return Json(new { Status = false });

            _db.Groups.Remove(model);
            _db.SaveChanges();
            return Json(new { Status = true });
        }
    }
}