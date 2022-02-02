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
    /// GAME_OBJECT: BankDepositMenu
    /// DESCRIPTION: Class that controls behaviour of BankDepositMenu
    /// </summary>
    public class BankDepositMenu : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields

        public PlayerData PlayerData;
        public Button Deposit;
        public TMP_InputField DepositAmount;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            RegisterButtonsListeners();
        }

        private void OnDestroy()
        {
            DepositAmount.onValueChanged.RemoveAllListeners();
        }

        private void RegisterButtonsListeners()
        {
            Deposit.OnClickAsObservable()
                .Subscribe(HandleDepositButtonCLick)
                .AddTo(this);
            PlayerData.Player.CurrentCash
                .Subscribe(HandleDepositAmount)
                .AddTo(this);
            DepositAmount.onValueChanged.AddListener(OnValueChanged);
        }

        private void HandleDepositButtonCLick(Unit unit)
        {
            var result = float.Parse(DepositAmount.text);
            if (result > 0f)
            {
                PlayerData.Player.CurrentCash.Value -= result;
                PlayerData.Player.CurrentDeposit.Value += result;
            }
            MessageBroker.Default.Publish(new ExitCurrentMenuCalled());
        }

        private void HandleDepositAmount(float depositAmount)
        {
            DepositAmount.SetTextWithoutNotify(depositAmount.ToString(Constants.StringFormats.NUMBER_FORMAT));
        }
        private void OnValueChanged(string userInput)
        {
            if (userInput.All(char.IsNumber) && !userInput.Equals(string.Empty))
            {
                var userInputFloat = float.Parse(userInput);
                if (userInputFloat < 0f || userInputFloat > PlayerData.Player.CurrentCash.Value)
                {
                    DepositAmount.SetTextWithoutNotify(PlayerData.Player.CurrentCash.Value.ToString(Constants.StringFormats.NUMBER_FORMAT));
                }
            }
            else
            {
                DepositAmount.SetTextWithoutNotify("0");
            }
        }

        #endregion
    }
}