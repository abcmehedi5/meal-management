using System.ComponentModel.DataAnnotations;

namespace meal_management.Model.Dto
{
    public class MarketDto
    {
        public int marketId { get; set; }
        public DateTime? date { get; set; } = default(DateTime?);
        public double dailyMarket { get; set; }
        public int dailyMeal { get; set; }
        public int totalMeal { get; set; }
        public double totalMarket { get; set; }
    }


    public class TotalDto
    {
      
        public int totalMeal { get; set; }
        public double totalMarket { get; set; }
        public double totalMealRate { get; set; }
    }

}
