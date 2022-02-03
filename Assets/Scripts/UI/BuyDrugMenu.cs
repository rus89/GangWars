using System;
using System.Globalization;
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
    public class BuyDrugMenu : MonoBehaviour
    {
        #region Private Fields
        
        private int _drugAmount;

        #endregion





        #region Public Fields

        public PlayerData PlayerData;
        public Button Buy;
        public Button Exit;
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
            _drugAmount = (int) (PlayerData.Player.CurrentCash.Value / PlayerData.Player.SelectedMarketDrug.Value.drugPrice.Value);
            DrugAmount.SetTextWithoutNotify(_drugAmount.ToString());
        }

        private void OnDestroy()
        {
            DrugAmount.onValueChanged.RemoveAllListeners();
        }

        private void RegisterButtonsListeners()
        {
            Buy.OnClickAsObservable()
                .Subscribe(HandleBuyButtonClick)
                .AddTo(this);
            Exit.OnClickAsObservable()
                .Subscribe(HandleExitButtonClick)
                .AddTo(this);
            DrugAmount.onValueChanged.AddListener(OnValueChanged);
        }

        private void HandleBuyButtonClick(Unit obj)
        {
            _drugAmount = int.Parse(DrugAmount.text);
            if (_drugAmount > 0)
            {
                PlayerData.Player.CurrentCash.Value -= _drugAmount * PlayerData.Player.SelectedMarketDrug.Value.drugPrice.Value;
                if (PlayerData.Player.InventoryDrugs.Any(drug => drug.drugType == PlayerData.Player.SelectedMarketDrug.Value.drugType))
                {
                    PlayerData.Player.InventoryDrugs.First(drug => drug.drugType == PlayerData.Player.SelectedMarketDrug.Value.drugType).drugAmount.Value += _drugAmount;
                }
                else
                {
                    PlayerData.Player.SelectedMarketDrug.Value.drugAmount.Value = _drugAmount;
                    PlayerData.Player.InventoryDrugs.Add(PlayerData.Player.SelectedMarketDrug.Value);
                }
            }
            MessageBroker.Default.Publish(new ExitCurrentMenuCalled());
        }

        private void HandleExitButtonClick(Unit obj)
        {
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
