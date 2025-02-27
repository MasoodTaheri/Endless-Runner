using System;

[Serializable]
public class UIModel
{
    public int CoinScoreFactor = 4;
    public int StarScoreFactor = 10;
    public int coinCount;
    public int StarCount;
    public int score;

    public void AddStar(int arg0)
    {
        StarCount += arg0;
        score += arg0 * StarScoreFactor;
    }

    public void AddCoin(int arg0)
    {
        coinCount += arg0;
        score += arg0 * CoinScoreFactor;
    }
}