using System.ComponentModel.DataAnnotations;

namespace meal_management.Model
{
    public class MealManageModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? email { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public int meal { get; set; }

        [Required]
        public double diposit { get; set; }

    }
}
