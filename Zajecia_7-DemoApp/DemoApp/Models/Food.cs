using System.Collections.Generic;

namespace DemoApp.Models
{
    public class Food
    {
        public enum HotLevel
        {
            Mild,
            Medium,
            Hot,
            ExtraHot
        }
  
        public enum FoodType
        {
            Unknown,
            Fish,
            Meat,
            Mix,
            Soup,
            Vege
        }

        public int FoodId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        public HotLevel? Hot { get; set; }
        public FoodType? Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}