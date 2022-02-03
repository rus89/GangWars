using System.Linq;
using LotusGangWars.Game;
using LotusGangWars.Utilities;
using TMPro;
using UniRx;
using Unity.Linq;
using UnityEditor;
using UnityEngine;

namespace LotusGangWars
{
    public class DrugPresenter : MonoBehaviour
    {
        public PlayerData PlayerData;
        public GameData GameData;
        
        public Drug.DrugTypeEnum DrugType;
        public TMP_Text DrugPrice;

#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_OSX
        private void OnValidate()
        {
            PlayerData = AssetDatabase.FindAssets(nameof(PlayerData), new []{"Assets/ScriptableObjects"})
                .Select(s => AssetDatabase.LoadAssetAtPath<PlayerData>(AssetDatabase.GUIDToAssetPath(s)))
                .First();
            GameData = AssetDatabase.FindAssets(nameof(GameData), new []{"Assets/ScriptableObjects"})
                .Select(s => AssetDatabase.LoadAssetAtPath<GameData>(AssetDatabase.GUIDToAssetPath(s)))
                .First();
            DrugPrice = gameObject.Children().First(child => child.name.Contains("DrugPrice")).GetComponent<TMP_Text>();
        }
#endif

        private void OnEnable()
        {
            GameData.GameGlobalData.DrugsAtCurrentMarket
                .First(drug => drug.drugType == DrugType).drugPrice
                .Subscribe(ShowPrice)
                .AddTo(this);
        }

        private void ShowPrice(float price)
        {
            DrugPrice.SetText(price.ToString(Constants.StringFormats.CURRENCY_FORMAT));
        }
    }
}