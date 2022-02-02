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
    /// SCENE: Main
    /// GAME_OBJECT: BankWithdrawMenu
    /// DESCRIPTION: Class that controls behaviour of Bank Withdraw menu
    /// </summary>
    public class BankWithdrawMenu : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields

        public PlayerData PlayerData;
        public Button Withdraw;
        public TMP_InputField WithdrawAmount;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            RegisterButtonsListeners();
        }

        private void OnDestroy()
        {
            WithdrawAmount.onValueChanged.RemoveAllListeners();
        }

        private void RegisterButtonsListeners()
        {
            Withdraw.OnClickAsObservable()
                .Subscribe(HandleWithdrawButtonClick)
                .AddTo(this);
            PlayerData.Player.CurrentDeposit
                .Subscribe(HandleWithdrawAmount)
                .AddTo(this);
            WithdrawAmount.onValueChanged.AddListener(OnValueChanged);
        }

        private void HandleWithdrawButtonClick(Unit unit)
        {
            var result = float.Parse(WithdrawAmount.text);
            if (result > 0f)
            {
                PlayerData.Player.CurrentCash.Value += result;
                PlayerData.Player.CurrentDeposit.Value -= result;
            }
            MessageBroker.Default.Publish(new ExitCurrentMenuCalled());
        }

        private void HandleWithdrawAmount(float withdrawAmount)
        {
            WithdrawAmount.SetTextWithoutNotify(withdrawAmount.ToString(Constants.StringFormats.NUMBER_FORMAT));
        }

        private void OnValueChanged(string userInput)
        {
            if (userInput.All(char.IsNumber) && !userInput.Equals(string.Empty))
            {
                var userInputFloat = float.Parse(userInput);
                if (userInputFloat < 0f || userInputFloat > PlayerData.Player.CurrentDeposit.Value)
                {
                    WithdrawAmount.SetTextWithoutNotify(PlayerData.Player.CurrentDeposit.Value.ToString(Constants.StringFormats.NUMBER_FORMAT));
                }
            }
            else
            {
                WithdrawAmount.SetTextWithoutNotify("0");
            }
        }

        #endregion
    }
}
