using System;
using LotusGangWars.Game;
using UniRx;

namespace LotusGangWars
{
    [Serializable]
    public sealed class Player
    {
        public enum CitiesEnum
        {
            Tokyo,
            Delphi,
            Shanghai,
            Bangkok,
            Manila,
            Seoul
        }

        public CitiesEnum CurrentCity = CitiesEnum.Tokyo;
        public FloatReactiveProperty CurrentCash = new FloatReactiveProperty(2000);
        public IntReactiveProperty CurrentGuns = new IntReactiveProperty(0);
        public IntReactiveProperty CurrentHealth = new IntReactiveProperty(100);
        public FloatReactiveProperty CurrentDeposit = new FloatReactiveProperty(0f);
        public FloatReactiveProperty CurrentDebt = new FloatReactiveProperty(5500f);
        public ReactiveProperty<IDrug> SelectedMarketDrug = new ReactiveProperty<IDrug>(null);
        public ReactiveProperty<IDrug> SelectedInventoryDrug = new ReactiveProperty<IDrug>(null);
        public ReactiveCollection<IDrug> InventoryDrugs = new ReactiveCollection<IDrug>();
        public ReactiveCollection<FloatReactiveProperty> AllHighScores = new ReactiveCollection<FloatReactiveProperty>();

        public Player()
        {
            ResetValues();
        }

        public void ResetValues()
        {
            CurrentCity = CitiesEnum.Tokyo;
            CurrentCash.Value = 2000;
            CurrentGuns.Value = 0;
            CurrentHealth.Value = 100;
            CurrentDeposit.Value = 0;
            CurrentDebt.Value = 5500;
            SelectedInventoryDrug = null;
            SelectedMarketDrug = null;
            InventoryDrugs.Clear();
        }
    }
}