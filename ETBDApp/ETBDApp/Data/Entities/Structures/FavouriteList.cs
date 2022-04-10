namespace ETBDApp.Data.Entities
{
    public class FavouriteList
    {
        public int Id { get; set; }

        public Food Food { get; set; }

        public User User { get; set; }

        public DateTime CreationDate { get; set; }
    }
}