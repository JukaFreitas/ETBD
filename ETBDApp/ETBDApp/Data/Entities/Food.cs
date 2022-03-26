
namespace ETBDApp.Data.Entities
{
    public class Food
    {
        public int Id { get; set; }


        [Required]
        public Category Category { get; set; }  

        [Required]
        public string Name { get; set; }
    }
}
