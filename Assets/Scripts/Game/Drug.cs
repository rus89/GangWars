using UnityEngine;

namespace LotusGangWars
{
    public class Drug : MonoBehaviour
    {
        public enum TradingTypeEnum
        {
            Inventory,
            Market
        }
        
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

        public TradingTypeEnum TradingType;
        public DrugTypeEnum DrugType;
        public float DrugPrice;
        public int DrugAmount;
        public Player.CitiesEnum[] AvailableCities;
    }
}