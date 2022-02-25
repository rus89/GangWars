using Lean.Gui;
using LotusGangWars.Utilities;
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
    public class WelcomeScreenMenu : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields

        public Button Ok;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            Ok.OnClickAsObservable()
                .Subscribe(HandleOkButtonClick)
                .AddTo(this);
        }

        private void HandleOkButtonClick(Unit obj)
        {
            MessageBroker.Default.Publish(new ConnectWalletMenuCalled());
            gameObject.GetComponent<LeanWindow>().TurnOff();
        }

        #endregion
    }
}
