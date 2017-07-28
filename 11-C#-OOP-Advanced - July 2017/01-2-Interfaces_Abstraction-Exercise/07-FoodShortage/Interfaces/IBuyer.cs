namespace _07_FoodShortage.Interfaces
    {
    public interface IBuyer
        {
        int Food { get; }

        string Name { get; }

        void BuyFood();
        }
    }
