using System.ComponentModel.DataAnnotations;

namespace meal_management.Model
{
    public class MarketModel
    {
        [Key]
        public int marketId { get; set; }

        [Required]
        public DateTime? date { get; set; } = default(DateTime?);

        [Required]
        public double dailyMarket { get; set; }

        [Required]
        public int dailyMeal { get; set; }
    }
}
