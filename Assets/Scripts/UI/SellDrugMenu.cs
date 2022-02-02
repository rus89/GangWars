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
    public class SellDrugMenu : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields

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
            ExitButton.OnClickAsObservable()
                .Subscribe(_ => MessageBroker.Default.Publish(new ExitCurrentMenuCalled()))
                .AddTo(this);
        }

        #endregion
    }
}
