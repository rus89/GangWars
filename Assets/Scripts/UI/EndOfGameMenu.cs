using LotusGangWars.Utilities;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace LotusGangWars.UI
{
    /// <summary>
    /// SCENE: Main
    /// GAME_OBJECT: EndOfGameMenu
    /// DESCRIPTION: Class that controls behaviour of the end of the game menu
    /// </summary>
    public class EndOfGameMenu : MonoBehaviour
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
                .Subscribe(_ => MessageBroker.Default.Publish(new MainMenuCalled()))
                .AddTo(this);
        }

        #endregion
    }
}
