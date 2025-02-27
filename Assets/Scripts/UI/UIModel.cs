using System;
using UnityEngine.Serialization;

namespace UI
{
    [Serializable]
    public class UIModel
    {
        public int CoinScoreFactor = 4;
        public int StarScoreFactor = 10;
        public int CoinCount;
        public int StarCount;
        public int Score;

        public void AddStar(int arg0)
        {
            StarCount += arg0;
            Score += arg0 * StarScoreFactor;
        }

        public void AddCoin(int arg0)
        {
            CoinCount += arg0;
            Score += arg0 * CoinScoreFactor;
        }
    }
}