using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERestaurant.DAO;
using ERestaurant.DAO.Model;
using ERestaurant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERestaurant.Controllers
{
    public class TakeOutController : Controller
    {
        private readonly MyContext _db;
        public TakeOutController(MyContext dbContex)
        {
            _db = dbContex;
        }

        [Authorize(Roles = "1")]
        public IActionResult Order()
        {
            return View();
        }


        public IActionResult GetOrders(int pageSize, int pageNo)
        {
            try
            {
                var data = from a in _db.TakeOuts
                           join d in _db.Accounts
                           on a.AccountId equals d.Id
                           select new TakeOutModel
                           {
                               Id = a.Id,
                               Name = d.Name,
                               Address = d.Address,
                               Phone = d.Phone,
                               CreateTime = a.CreateTime,
                               Status = a.Status,
                               Price = a.Price
                           };

                var total = data.Count();
                var orders = data.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                var orderIds = orders.Select(x => x.Id).ToList();
                var foods = (from a in _db.TakeOutAndFoods.Where(x => orderIds.Contains(x.OrderId))
                             join b in _db.Foods
                             on a.FoodId equals b.Id
                             select new
                             {
                                 a.OrderId,
                                 b.Name,
                                 a.Count
                             }).ToList();

                orders.ForEach(x =>
                {
                    var foodList = foods.Where(y => y.OrderId == x.Id)
                        .Select(y => new Tuple<string, int>(y.Name, y.Count)).ToList();
                    x.FoodDic = foodList;
                });

                return Json(new { Status = true, Data = orders, Total = total });
            }
            catch(Exception ex)
            {
                return Json(new { Status = false });
            }
        }

        public IActionResult UpdateStatus(int id, string status)
        {
            var order = _db.TakeOuts.FirstOrDefault(x => x.Id == id);
            if (order == null) return Json(new { Status = false });

            order.Status = status;

            return Json(new { Status = _db.SaveChanges() > 0});
        }


        [Authorize]
        public IActionResult AddOrder(decimal totalPrice, string foodIds)
        {
            var userIdStr = User.Claims.SingleOrDefault(s => s.Type == "LoginId").Value;
            int.TryParse(userIdStr, out int userId);
            if (userId == 0) return Json(0);

            var order = new TakeOut()
            {
                AccountId = userId,
                Price = totalPrice,
                Status = "已付款",
                CreateTime = DateTime.Now
            };
            _db.TakeOuts.Add(order);
            _db.SaveChanges();

            var splitedIds = foodIds.Split(',');
            var addedFoods = new List<TakeOutAndFood>();
            foreach (var id in splitedIds)
            {
                int.TryParse(id, out int foodId);
                var added = addedFoods.FirstOrDefault(x => x.FoodId == foodId);
                if (added == null)
                {
                    var orderFood = new TakeOutAndFood()
                    {
                        OrderId = order.Id,
                        FoodId = foodId,
                        Count = 1
                    };
                    _db.TakeOutAndFoods.Add(orderFood);
                    addedFoods.Add(orderFood);
                }
                else
                {
                    added.Count++;
                }
            }
             _db.SaveChanges();

            return Json(1);
        }
    }
}