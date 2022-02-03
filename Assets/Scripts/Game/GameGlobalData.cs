using System;
using LotusGangWars.Game;
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
        public ReactiveCollection<IDrug> DrugsAtCurrentMarket = new ReactiveCollection<IDrug>();
        public ReactiveDictionary<Player.CitiesEnum, float> PriceFactorsPerMarket = new ReactiveDictionary<Player.CitiesEnum, float>
        {
            { Player.CitiesEnum.Tokyo, 1f },
            { Player.CitiesEnum.Delphi, 2f },
            { Player.CitiesEnum.Shanghai, 0.5f },
            { Player.CitiesEnum.Bangkok, 3f },
            { Player.CitiesEnum.Manila, 0.25f },
            { Player.CitiesEnum.Seoul, 0.75f }
        };

        private static readonly ReactiveCollection<IDrug> AllDrugs = new ReactiveCollection<IDrug>
        {
            new Drug(Drug.DrugTypeEnum.Acid, 575, 0),
            new Drug(Drug.DrugTypeEnum.Cocaine, 22239, 0),
            new Drug(Drug.DrugTypeEnum.Hashish, 893, 0),
            new Drug(Drug.DrugTypeEnum.Heroin, 10212, 0),
            new Drug(Drug.DrugTypeEnum.Ludes, 46, 0),
            new Drug(Drug.DrugTypeEnum.Opium, 1218, 0),
            new Drug(Drug.DrugTypeEnum.Peyote, 504, 0),
            new Drug(Drug.DrugTypeEnum.Shrooms, 853, 0),
            new Drug(Drug.DrugTypeEnum.Speed, 243, 0),
            new Drug(Drug.DrugTypeEnum.Weed, 722, 0),
            new Drug(Drug.DrugTypeEnum.MDA, 2192, 0),
            new Drug(Drug.DrugTypeEnum.PCP, 1841, 0),
        };
        public ReactiveDictionary<Player.CitiesEnum, ReactiveCollection<IDrug>> AllDrugsInAllMarkets = new ReactiveDictionary<Player.CitiesEnum, ReactiveCollection<IDrug>>
        {
            {
                Player.CitiesEnum.Tokyo,
                new ReactiveCollection<IDrug>
                {
                    AllDrugs[(int)Drug.DrugTypeEnum.Acid],
                    AllDrugs[(int)Drug.DrugTypeEnum.Cocaine],
                    AllDrugs[(int)Drug.DrugTypeEnum.Hashish],
                    AllDrugs[(int)Drug.DrugTypeEnum.Heroin],
                    AllDrugs[(int)Drug.DrugTypeEnum.Ludes],
                    AllDrugs[(int)Drug.DrugTypeEnum.Opium],
                    AllDrugs[(int)Drug.DrugTypeEnum.Peyote],
                    AllDrugs[(int)Drug.DrugTypeEnum.Shrooms],
                    AllDrugs[(int)Drug.DrugTypeEnum.Speed],
                    AllDrugs[(int)Drug.DrugTypeEnum.Weed],
                    AllDrugs[(int)Drug.DrugTypeEnum.MDA],
                    AllDrugs[(int)Drug.DrugTypeEnum.PCP],
                }
            },
            {
                Player.CitiesEnum.Delphi,
                new ReactiveCollection<IDrug>
                {
                    AllDrugs[(int)Drug.DrugTypeEnum.Cocaine],
                    AllDrugs[(int)Drug.DrugTypeEnum.Hashish],
                    AllDrugs[(int)Drug.DrugTypeEnum.Ludes],
                    AllDrugs[(int)Drug.DrugTypeEnum.Opium],
                    AllDrugs[(int)Drug.DrugTypeEnum.Shrooms],
                    AllDrugs[(int)Drug.DrugTypeEnum.Speed],
                    AllDrugs[(int)Drug.DrugTypeEnum.MDA],
                    AllDrugs[(int)Drug.DrugTypeEnum.PCP]
                }
            },
            {
                Player.CitiesEnum.Shanghai,
                new ReactiveCollection<IDrug>
                {
                    AllDrugs[(int)Drug.DrugTypeEnum.Acid],
                    AllDrugs[(int)Drug.DrugTypeEnum.Hashish],
                    AllDrugs[(int)Drug.DrugTypeEnum.Ludes],
                    AllDrugs[(int)Drug.DrugTypeEnum.Peyote],
                    AllDrugs[(int)Drug.DrugTypeEnum.Speed],
                    AllDrugs[(int)Drug.DrugTypeEnum.MDA]
                }
            },
            {
                Player.CitiesEnum.Bangkok,
                new ReactiveCollection<IDrug>
                {
                    AllDrugs[(int)Drug.DrugTypeEnum.Acid],
                    AllDrugs[(int)Drug.DrugTypeEnum.Cocaine],
                    AllDrugs[(int)Drug.DrugTypeEnum.Hashish],
                    AllDrugs[(int)Drug.DrugTypeEnum.Ludes],
                    AllDrugs[(int)Drug.DrugTypeEnum.Opium],
                    AllDrugs[(int)Drug.DrugTypeEnum.Peyote],
                    AllDrugs[(int)Drug.DrugTypeEnum.Speed],
                    AllDrugs[(int)Drug.DrugTypeEnum.Weed],
                    AllDrugs[(int)Drug.DrugTypeEnum.MDA],
                }
            },
            {
                Player.CitiesEnum.Manila,
                new ReactiveCollection<IDrug>
                {
                    AllDrugs[(int)Drug.DrugTypeEnum.Acid],
                    AllDrugs[(int)Drug.DrugTypeEnum.Cocaine],
                    AllDrugs[(int)Drug.DrugTypeEnum.Heroin],
                    AllDrugs[(int)Drug.DrugTypeEnum.Ludes],
                    AllDrugs[(int)Drug.DrugTypeEnum.Peyote],
                    AllDrugs[(int)Drug.DrugTypeEnum.Shrooms],
                    AllDrugs[(int)Drug.DrugTypeEnum.Weed],
                    AllDrugs[(int)Drug.DrugTypeEnum.MDA]
                }
            },
            {
                Player.CitiesEnum.Seoul,
                new ReactiveCollection<IDrug>
                {
                    AllDrugs[(int)Drug.DrugTypeEnum.Cocaine],
                    AllDrugs[(int)Drug.DrugTypeEnum.Hashish],
                    AllDrugs[(int)Drug.DrugTypeEnum.Heroin],
                    AllDrugs[(int)Drug.DrugTypeEnum.Opium],
                    AllDrugs[(int)Drug.DrugTypeEnum.Peyote],
                    AllDrugs[(int)Drug.DrugTypeEnum.Shrooms],
                    AllDrugs[(int)Drug.DrugTypeEnum.Weed],
                    AllDrugs[(int)Drug.DrugTypeEnum.MDA],
                    AllDrugs[(int)Drug.DrugTypeEnum.PCP]
                }
            }
        };
        
        public ReactiveDictionary<Player.CitiesEnum, ReactiveCollection<Drug.DrugTypeEnum>> MarketsDrugs = new ReactiveDictionary<Player.CitiesEnum, ReactiveCollection<Drug.DrugTypeEnum>>
        {
            {
                Player.CitiesEnum.Tokyo,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Heroin, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Peyote,
                    Drug.DrugTypeEnum.Shrooms, Drug.DrugTypeEnum.Speed, Drug.DrugTypeEnum.Weed, Drug.DrugTypeEnum.MDA, Drug.DrugTypeEnum.PCP
                }
            },
            {
                Player.CitiesEnum.Delphi,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Shrooms, Drug.DrugTypeEnum.Speed, Drug.DrugTypeEnum.MDA,
                    Drug.DrugTypeEnum.PCP
                }
            },
            {
                Player.CitiesEnum.Shanghai,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Speed, Drug.DrugTypeEnum.MDA
                }
            },
            {
                Player.CitiesEnum.Bangkok,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Speed,
                    Drug.DrugTypeEnum.Weed, Drug.DrugTypeEnum.MDA
                }
            },
            {
                Player.CitiesEnum.Manila,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Acid, Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Heroin, Drug.DrugTypeEnum.Ludes, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Shrooms, Drug.DrugTypeEnum.Weed,
                    Drug.DrugTypeEnum.MDA
                }
            },
            {
                Player.CitiesEnum.Seoul,
                new ReactiveCollection<Drug.DrugTypeEnum>
                {
                    Drug.DrugTypeEnum.Cocaine, Drug.DrugTypeEnum.Hashish, Drug.DrugTypeEnum.Heroin, Drug.DrugTypeEnum.Opium, Drug.DrugTypeEnum.Peyote, Drug.DrugTypeEnum.Shrooms,
                    Drug.DrugTypeEnum.Weed, Drug.DrugTypeEnum.MDA, Drug.DrugTypeEnum.PCP
                }
            }
        };

        public void ResetValues()
        {
            CurrentDay.Value = 1;
        }
    }
}