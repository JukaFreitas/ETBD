namespace ETBDApp.Data.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public Category Category { get; set; }  

        [Required]
        public string FoodName { get; set; }
    }
}
