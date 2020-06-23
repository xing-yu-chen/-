using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERestaurant.Models
{
    public class TakeOutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }

        public List<Tuple<string, int>> FoodDic { get; set; }
    }
}
