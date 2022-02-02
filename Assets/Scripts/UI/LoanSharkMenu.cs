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
    public class LoanSharkMenu : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields
        
        public PlayerData PlayerData;

        public Button Repay;
        public Button DontRepay;
        public TMP_InputField RepayAmount;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            RegisterObservableListeners();
        }

        private void OnDestroy()
        {
            RepayAmount.onValueChanged.RemoveAllListeners();
        }

        private void RegisterObservableListeners()
        {
            Repay.OnClickAsObservable()
                .Subscribe(HandleRepayButtonClick)
                .AddTo(this);
            DontRepay.OnClickAsObservable()
                .Subscribe(HandleDontRepayButtonClick)
                .AddTo(this);
            PlayerData.Player.CurrentCash
                .Subscribe(HandleShowingRepayAmount)
                .AddTo(this);
            RepayAmount.onValueChanged.AddListener(OnValueChanged);
        }
        private void HandleRepayButtonClick(Unit obj)
        {
            var result = float.Parse(RepayAmount.text);
            if (result > 0f)
            {
                PlayerData.Player.CurrentCash.Value -= result;
                PlayerData.Player.CurrentDebt.Value -= result;
            }
            MessageBroker.Default.Publish(new BankMenuCalled());
        }

        private void HandleDontRepayButtonClick(Unit unit)
        {
            MessageBroker.Default.Publish(new BankMenuCalled());
        }

        private void HandleShowingRepayAmount(float amount)
        {
            RepayAmount.SetTextWithoutNotify(amount.ToString(Constants.StringFormats.NUMBER_FORMAT));
        }


        private void OnValueChanged(string userInput)
        {
            if (userInput.All(char.IsNumber) && !userInput.Equals(string.Empty))
            {
                var userInputFloat = float.Parse(userInput);
                if (userInputFloat < 0f || userInputFloat > PlayerData.Player.CurrentCash.Value)
                {
                    RepayAmount.SetTextWithoutNotify(PlayerData.Player.CurrentCash.Value.ToString(Constants.StringFormats.NUMBER_FORMAT));
                }
            }
            else
            {
                RepayAmount.SetTextWithoutNotify("0");
            }
        }
        
        #endregion
    }
}