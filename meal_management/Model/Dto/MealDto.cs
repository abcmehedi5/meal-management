using System.ComponentModel.DataAnnotations;

namespace meal_management.Model.Dto
{
    public class MealDto
    {
        public int id { get; set; }
        public string? email { get; set; }
        public string? name { get; set; }
        public int meal { get; set; }
        public double diposit { get; set; }
        public double due { get; set; }
        public double Refund { get; set; }
        public double totalCost { get; set; }
        public double mealRate { get; set; }
    }
}
