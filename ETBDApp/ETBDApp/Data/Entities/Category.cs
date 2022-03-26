namespace ETBDApp.Data.Entities
{
    public class Category
    {

        public int Id { get; set; } 

        [Required]
        public string CategoryName { get; set; }

        
    }
}
