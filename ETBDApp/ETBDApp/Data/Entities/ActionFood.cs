namespace ETBDApp.Data.Entities
{
    public class ActionFood
    {
        public Action Action { get; set; }
        public Food Food { get; set; }

        public int ActionId { get; set; }
        public int FoodId { get; set; } 

    }
}
