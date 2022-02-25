using System.Collections;
using System.Runtime.InteropServices;
using LotusGangWars.Utilities;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace LotusGangWars.UI
{
    /// <summary>
    /// SCENE: Main
    /// GAME_OBJECT: ConnectWallet
    /// DESCRIPTION: Class that controls the behaviour of connect wallet menu
    /// </summary>
    public class ConnectWalletMenu : MonoBehaviour
    {
        #region Private Fields

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [DllImport("__Internal")]
        private static extern void ConnectWallet();

        #endregion


        #region Public Fields

        [Header("SO")] 
        public PlayerData PlayerData;

        [Header("UI")] 
        public RawImage ProfileImage;
        public TMP_InputField UserName;
        public Button ConnectWalletButton;
        public TMP_Text ConnectWalletButtonText;

        #endregion


        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            RegisterButtonsListeners();
        }

        private void OnDestroy()
        {
            _compositeDisposable.Dispose();
            UserName.onValueChanged.RemoveAllListeners();
        }

        private void RegisterButtonsListeners()
        {
            ConnectWalletButton.OnClickAsObservable()
                .Subscribe(HandleConnectWallet)
                .AddTo(_compositeDisposable);
            ConnectWalletButtonText
                .ObserveEveryValueChanged(tmpText => tmpText.text)
                .SkipWhile(text => !text.Contains("Start"))
                .Take(1)
                .Subscribe(text =>
                {
                    ConnectWalletButton.OnClickAsObservable()
                        .Subscribe(HandleStartButton)
                        .AddTo(this);
                })
                .AddTo(this);
            UserName.onValueChanged.AddListener(OnUserNameChanged);
        }

        private void HandleConnectWallet(Unit obj)
        {
            ConnectWallet();
            _compositeDisposable.Dispose();
        }

        private void HandleStartButton(Unit obj)
        {
            PlayerData.Player.UserName.Value = UserName.text;
            MessageBroker.Default.Publish(new MainMenuCalled());
        }

        private void OnUserNameChanged(string userInput)
        {
            PlayerData.Player.UserName.Value = userInput;
        }

        public void GetUserName(string userName)
        {
            UserName.SetTextWithoutNotify(userName);
        }

        public void GetProfilePicture(string url)
        {
            PlayerData.Player.UserProfileImage.Value = ProfileImage;
            StartCoroutine(GetProfilePictureRoutine(url));
        }

        private IEnumerator GetProfilePictureRoutine(string url)
        {
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogErrorFormat($"poruka iz unity - greska u skidanju slike");
                Debug.Log(uwr.error);
            }
            else
            {
                ProfileImage.texture = ((DownloadHandlerTexture) uwr.downloadHandler).texture;
                PlayerData.Player.UserProfileImage.Value = ProfileImage;
                ConnectWalletButtonText.SetText("Start");
            }
        }

        #endregion
    }
}