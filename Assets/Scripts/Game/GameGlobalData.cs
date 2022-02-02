using System;
using UniRx;

namespace LotusGangWars
{
    /// <summary>
    /// SCENE: /
    /// GAME_OBJECT: /
    /// DESCRIPTION: Class for storing game related data
    /// </summary>
    [Serializable]
    public class GameGlobalData
    {
        public IntReactiveProperty CurrentDay = new IntReactiveProperty(1);
        public FloatReactiveProperty DepositInterestRate = new FloatReactiveProperty(0.05f);
        public FloatReactiveProperty DebtInterestRate = new FloatReactiveProperty(0.1f);

        public void ResetValues()
        {
            CurrentDay.Value = 1;
        }
    }
}