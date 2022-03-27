namespace ETBDApp.Data.Entities
{
    public class FoodMeal
    {
        public Food Foods { get; set; }
        public Meal Meals { get; set; }

        public int FoodId { get; set; }
        public int MealId { get; set; }

        [Required]
        public PortionType PortionTypes { get; set; }

        [Required]
        public decimal Portion { get; set; }

    }
}
