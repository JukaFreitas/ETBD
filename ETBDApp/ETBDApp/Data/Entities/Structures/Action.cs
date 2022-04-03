


namespace ETBDApp.Data.Entities
{
    public class Action
    {

        public int Id { get; set; }


        [DisplayName("Action")]
        
        [Required]
        public string Name { get; set; }


    }
}
