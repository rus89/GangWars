using UniRx;

namespace LotusGangWars.Game
{
    /// <summary>
    /// SCENE:
    /// GAME_OBJECT:
    /// DESCRIPTION:
    /// </summary>
    public sealed class Drug : IDrug
    {
        public enum DrugTypeEnum
        {
            Acid,
            Heroin,
            PCP,
            Speed,
            Cocaine,
            Ludes,
            Peyote,
            Weed,
            Hashish,
            Opium,
            Shrooms,
            MDA
        }
        
        public DrugTypeEnum drugType { get; private set; }

        public FloatReactiveProperty drugPrice { get; private set; }

        public IntReactiveProperty drugAmount { get; private set; }

        public Drug()
        {
        }

        public Drug(DrugTypeEnum drugType, float drugPrice, int drugAmount)
        {
            this.drugType = drugType;
            this.drugPrice = new FloatReactiveProperty(drugPrice);
            this.drugAmount = new IntReactiveProperty(drugAmount);
        }
    }
}
