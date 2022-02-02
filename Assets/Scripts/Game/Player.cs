using System;
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
        public FloatReactiveProperty CurrentHighScore = new FloatReactiveProperty(0);
        public ReactiveCollection<FloatReactiveProperty> AllHighScores = new ReactiveCollection<FloatReactiveProperty>();
        public ReactiveCollection<Drug> InventoryDrugs = new ReactiveCollection<Drug>();
        public ReactiveDictionary<CitiesEnum, ReactiveCollection<Drug.DrugTypeEnum>> MarketsDrugs = new ReactiveDictionary<CitiesEnum, ReactiveCollection<Drug.DrugTypeEnum>>
        {
            {
                CitiesEnum.Tokyo,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Heroin, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Peyote,
                    Drug.DrugTypeEnum.Shrooms, Drug.DrugTypeEnum.Speed, Drug.DrugTypeEnum.Weed, Drug.DrugTypeEnum.MDA, Drug.DrugTypeEnum.PCP
                }
            },
            {
                CitiesEnum.Delphi,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Shrooms, Drug.DrugTypeEnum.Speed, Drug.DrugTypeEnum.MDA,
                    Drug.DrugTypeEnum.PCP
                }
            },
            {
                CitiesEnum.Shanghai,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Speed, Drug.DrugTypeEnum.MDA
                }
            },
            {
                CitiesEnum.Bangkok,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Speed,
                    Drug.DrugTypeEnum.Weed, Drug.DrugTypeEnum.MDA
                }
            },
            {
                CitiesEnum.Manila,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Heroin, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Shrooms, Drug.DrugTypeEnum.Weed,
                    Drug.DrugTypeEnum.MDA
                }
            },
            {
                CitiesEnum.Seoul,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Heroin, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Shrooms,
                    Drug.DrugTypeEnum.Weed, Drug.DrugTypeEnum.MDA, Drug.DrugTypeEnum.PCP
                }
            }
        };

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
            InventoryDrugs.Clear();
        }
    }
}