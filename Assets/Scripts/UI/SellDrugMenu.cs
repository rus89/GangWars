using System;
using System.Linq;
using LotusGangWars.Utilities;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace LotusGangWars.UI
{
    /// <summary>
    /// SCENE:
    /// GAME_OBJECT:
    /// DESCRIPTION:
    /// </summary>
    public class SellDrugMenu : MonoBehaviour
    {
        #region Private Fields

        private int _drugAmount;

        #endregion





        #region Public Fields

        public PlayerData PlayerData;
        public GameData GameData;
        public Button Sell;
        public Button ExitButton;
        public TMP_InputField DrugAmount;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            RegisterButtonsListeners();
        }

        private void OnEnable()
        {
            _drugAmount = PlayerData.Player.SelectedInventoryDrug.Value.drugAmount.Value;
            DrugAmount.SetTextWithoutNotify(_drugAmount.ToString());
        }

        private void OnDestroy()
        {
            DrugAmount.onValueChanged.RemoveAllListeners();
        }

        private void RegisterButtonsListeners()
        {
            Sell.OnClickAsObservable()
                .Subscribe(HandleSellButtonClick)
                .AddTo(this);
            ExitButton.OnClickAsObservable()
                .Subscribe(_ => MessageBroker.Default.Publish(new ExitCurrentMenuCalled()))
                .AddTo(this);
            DrugAmount.onValueChanged.AddListener(OnValueChanged);
        }

        private void HandleSellButtonClick(Unit obj)
        {
            _drugAmount = int.Parse(DrugAmount.text);
            if (_drugAmount > 0)
            {
                Sell.gameObject.SetActive(true);
                var marketPriceForSelectedInventoryDrug = GameData.GameGlobalData.DrugsAtCurrentMarket
                    .First(drug => drug.drugType == PlayerData.Player.SelectedInventoryDrug.Value.drugType);
                PlayerData.Player.CurrentCash.Value += _drugAmount * marketPriceForSelectedInventoryDrug.drugPrice.Value;
                if (Math.Abs(_drugAmount - PlayerData.Player.SelectedInventoryDrug.Value.drugAmount.Value) < 0.001f)
                {
                    PlayerData.Player.InventoryDrugs.Remove(PlayerData.Player.SelectedInventoryDrug.Value);
                }
                else
                {
                    PlayerData.Player.InventoryDrugs.First(drug => drug.drugType == PlayerData.Player.SelectedInventoryDrug.Value.drugType).drugAmount.Value -= _drugAmount;
                }
            }
            MessageBroker.Default.Publish(new ExitCurrentMenuCalled());
        }

        private void OnValueChanged(string userInput)
        {
            if (userInput.All(char.IsNumber) && !userInput.Equals(string.Empty))
            {
                var userInputFloat = float.Parse(userInput);
                if (userInputFloat < 0f || userInputFloat > _drugAmount)
                {
                    DrugAmount.SetTextWithoutNotify(_drugAmount.ToString());
                }
            }
            else
            {
                DrugAmount.SetTextWithoutNotify("0");
            }
        }

        #endregion
    }
}
