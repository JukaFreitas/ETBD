namespace ETBDApp.Data.Entities
{
    public class Meal
    {
        public int Id { get; set; }


        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public MealType MealType { get; set; }

        [Required]
        public List<FoodMeal> FoodMeals { get; set; }
    }
}
