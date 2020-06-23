using System;
using System.IO;
using System.Linq;
using ERestaurant.DAO;
using ERestaurant.DAO.Model;
using ERestaurant.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ERestaurant.Controllers
{
    public class FoodController : Controller
    {
        private readonly MyContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FoodController(MyContext dbContex, IHostingEnvironment hostingEnvironment)
        {
            _db = dbContex;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult FoodList()
        {
            return View();
        }

        public IActionResult GetFoodMenus(int pageSize, int pageNo, string type, string keyword)
        {
            var query = _db.Foods.AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(x => x.Type == type);
            }
            if(!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }

            var foods = query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            return Json(new { Status = true, Data = foods, Total = query.Count() });
        }

        public IActionResult AddFood([FromBody]FoodModel food)
        {
            if (food.Id > 0)
            {
                var model = _db.Foods.FirstOrDefault(x => x.Id == food.Id);
                if (model == null) return Json(new { Status = false }); 

                model.Image = food.Image;
                model.Name = food.Name;
                model.Description = food.Description;
                model.Type = food.Type;
                model.Price = food.Price;
                model.StockCount = food.StockCount;
            }
            else
            {
                var foodModel = new Food()
                {
                    Name = food.Name,
                    Description = food.Description,
                    Type = food.Type,
                    Image = food.Image,
                    Price = food.Price,
                    StockCount = food.StockCount,
                    CreateTime = DateTime.Now
                };
                _db.Foods.Add(foodModel);
            }

            return Json(new { Status = _db.SaveChanges() > 0 });
        }

        public IActionResult Delete(int id)
        {
            var model = _db.Foods.FirstOrDefault(x => x.Id == id);
            if (model == null)  return Json(new { Status = false});

            _db.Foods.Remove(model);
            return Json(new { Status = _db.SaveChanges() > 0 });
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            try
            {
                var fileCount = Request.Form.Files.Count;
                if (fileCount == 0) return Json(new { Success = false });

                var file = Request.Form.Files[0];
                var folder = _hostingEnvironment.WebRootPath + "/foodimg";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var physicalPath = Path.Combine(folder, Path.GetFileName(file.FileName));
                using (FileStream fs = System.IO.File.Create(physicalPath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                return Json(new { Success = true, fileName = $"/foodimg/{Path.GetFileName(file.FileName)}" });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
    }
}