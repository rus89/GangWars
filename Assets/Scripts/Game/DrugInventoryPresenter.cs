using System.Linq;
using LotusGangWars.Utilities;
using TMPro;
using UniRx;
using Unity.Linq;
using UnityEditor;
using UnityEngine;

namespace LotusGangWars.Game
{
    /// <summary>
    /// SCENE: Main
    /// GAME_OBJECT: All Inventory drugs game objects
    /// DESCRIPTION:
    /// </summary>
    public class DrugInventoryPresenter : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields

        
        public PlayerData PlayerData;
        public GameData GameData;
        
        public Drug.DrugTypeEnum DrugType;
        public TMP_Text DrugAmount;

        #endregion





        #region Monobehaviour Events

        

#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_OSX
        private void OnValidate()
        {
            PlayerData = AssetDatabase.FindAssets(nameof(PlayerData), new []{"Assets/ScriptableObjects"})
                .Select(s => AssetDatabase.LoadAssetAtPath<PlayerData>(AssetDatabase.GUIDToAssetPath(s)))
                .First();
            GameData = AssetDatabase.FindAssets(nameof(GameData), new []{"Assets/ScriptableObjects"})
                .Select(s => AssetDatabase.LoadAssetAtPath<GameData>(AssetDatabase.GUIDToAssetPath(s)))
                .First();
            DrugAmount = gameObject.Children().First(child => child.name.Contains("DrugAmount")).GetComponent<TMP_Text>();
        }
#endif

        private void OnEnable()
        {
            PlayerData.Player.InventoryDrugs
                .First(drug => drug.drugType == DrugType).drugAmount
                .Subscribe(ShowAmount)
                .AddTo(this);
        }

        private void ShowAmount(int amount)
        {
            DrugAmount.SetText(amount.ToString(Constants.StringFormats.NUMBER_FORMAT));
        }

        #endregion
    }
}
