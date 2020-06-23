using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERestaurant.Models
{
    public class FoodModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public string Image { get; set; }
}
}
