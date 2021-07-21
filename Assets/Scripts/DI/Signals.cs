public class GivePlayerPointsSignal
{
    public int Points { get; private set; }
    public GivePlayerPointsSignal(int points)
    {
        Points = points;
    }
}