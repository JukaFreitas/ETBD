namespace ETBDApp.Data.Interfaces
{
    public interface IDayValidator
    {
        bool IsSucessfulDay(User user, DateTime day);

        List<Action> GetMissingActions();
    }
}