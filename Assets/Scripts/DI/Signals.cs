namespace ShoppingGame
{

    public class GivePlayerCoinsSignal
    {
        public int Coins { get; private set; }
        public GivePlayerCoinsSignal(int points)
        {
            Coins = points;
        }
    }

    public class LoadSaveObjectSignal
    {
        public SaveSpace.SaveObject SaveObject { get; private set; }
        public LoadSaveObjectSignal(SaveSpace.SaveObject saveObject)
        {
            SaveObject = saveObject;
        }
    }
}