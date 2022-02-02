using LotusGangWars.Utilities;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace LotusGangWars.UI
{
    /// <summary>
    /// SCENE: Main
    /// GAME_OBJECT: BankMenu
    /// DESCRIPTION: Class that controls behaviour of Bank Menu
    /// </summary>
    public class BankMenu : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields

        public Button Deposit;
        public Button Withdraw;
        public Button ExitButton;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            RegisterButtonsListeners();
        }

        private void RegisterButtonsListeners()
        {
            Deposit.OnClickAsObservable()
                .Subscribe(HandleDepositButtonClick)
                .AddTo(this);
            Withdraw.OnClickAsObservable()
                .Subscribe(HandleWithdrawButtonClick)
                .AddTo(this);
            ExitButton.OnClickAsObservable()
                .Subscribe(HandleExitButtonClick)
                .AddTo(this);
        }

        private void HandleDepositButtonClick(Unit obj)
        {
            MessageBroker.Default.Publish(new BankDepositMenuCalled());
        }

        private void HandleWithdrawButtonClick(Unit obj)
        {
            MessageBroker.Default.Publish(new BankWithdrawMenuCalled());
        }

        private void HandleExitButtonClick(Unit unit)
        {
            MessageBroker.Default.Publish(new ExitCurrentMenuCalled());
        }

        #endregion
    }
}
