using System.ComponentModel;

namespace ETBDApp.Data.Entities
{
    public class Category
    {
        public int Id { get; set; } 

        [DisplayName("Category")]
        
        [Required]
        public string Name { get; set; }

        
    }
}
