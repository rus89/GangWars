using Lean.Gui;
using LotusGangWars.Utilities;
using RSG;
using UniRx;
using UnityEngine;

namespace LotusGangWars.UI
{
    /// <summary>
    /// SCENE: Main
    /// GAME_OBJECT: canvas
    /// DESCRIPTION: Object that controls menus
    /// </summary>
    public class UIInMainScene : MonoBehaviour
    {
        #region Private Fields

        private IState _rootState;

        /// <summary>
        /// Consts
        /// </summary>
        private const string INITIALIZATION_STATE = Constants.MenusStatesNames.INITIALIZATION;

        #endregion
        
        
        
        
        
        
        #region Public Fields

        [Header("SO")]
        public PlayerData PlayerData;

        [Header("Menus")] 
        public LeanWindow WelcomeMenu;
        public LeanWindow MainMenu;
        public LeanWindow EndOfGameMenu;
        public LeanWindow BankMenu;
        public LeanWindow BankDepositMenu;
        public LeanWindow BankWithdrawMenu;
        public LeanWindow LoanSharkMenu;
        public LeanWindow BuyDrugMenu;
        public LeanWindow SellDrugMenu;
        //TODO: sledece menije tek treba napraviti
        public LeanWindow ConnectWallet;
        public LeanWindow PubMenu;
        public LeanWindow GunsHouseMenu;
        public LeanWindow PoliceFightMenu;
        public LeanWindow InfoMenu;
        public LeanWindow HighScoreMenu;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            SetMenuStates();
            _rootState.ChangeState(INITIALIZATION_STATE);
        }

        private void OnDestroy()
        {
            _rootState.Exit();
        }

        private void SetMenuStates()
        {
            _rootState = new StateMachineBuilder()
                .State<Constants.MenusStatesTypes.Normal>(INITIALIZATION_STATE)
                    .Enter(state => HandleEnteringInitializationState())
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.WELCOME_SCREEN)
                    .Enter(state => ShowMenu(WelcomeMenu))
                    .Exit(state => HideMenu(WelcomeMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.CONNECT_WALLET)
                    .Enter(state => ShowMenu(ConnectWallet))
                    .Exit(state => HideMenu(ConnectWallet))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.MAIN)
                    .Enter(state => ShowMenu(MainMenu))
                    .Exit(state => HideMenu(MainMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.END_OF_GAME)
                    .Enter(state => ShowMenu(EndOfGameMenu))
                    .Exit(state => HideMenu(EndOfGameMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.BANK)
                    .Enter(state => ShowMenu(BankMenu))
                    .Exit(state => HideMenu(BankMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.BANK_DEPOSIT)
                    .Enter(state => ShowMenu(BankDepositMenu))
                    .Exit(state => HideMenu(BankDepositMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.BANK_WITHDRAW)
                    .Enter(state => ShowMenu(BankWithdrawMenu))
                    .Exit(state => HideMenu(BankWithdrawMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.LOAN_SHARK)
                    .Enter(state => ShowMenu(LoanSharkMenu))
                    .Exit(state => HideMenu(LoanSharkMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.BUY_DRUG)
                    .Enter(state => ShowMenu(BuyDrugMenu))
                    .Exit(state => HideMenu(BuyDrugMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.SELL_DRUG)
                    .Enter(state => ShowMenu(SellDrugMenu))
                    .Exit(state => HideMenu(SellDrugMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.PUB)
                    .Enter(state => ShowMenu(PubMenu))
                    .Exit(state => HideMenu(PubMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.GUNS_HOUSE)
                    .Enter(state => ShowMenu(GunsHouseMenu))
                    .Exit(state => HideMenu(GunsHouseMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.POLICE_FIGHT)
                    .Enter(state => ShowMenu(PoliceFightMenu))
                    .Exit(state => HideMenu(PoliceFightMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.INFO)
                    .Enter(state => ShowMenu(InfoMenu))
                    .Exit(state => HideMenu(InfoMenu))
                .End()
                .State<Constants.MenusStatesTypes.Normal>(Constants.Menus.HIGH_SCORE)
                    .Enter(state => ShowMenu(HighScoreMenu))
                    .Exit(state => HideMenu(HighScoreMenu))
                .End()
                .Build();
        }

        private void ShowMenu(LeanWindow leanWindow)
        {
            leanWindow.gameObject.SetActive(true);
            leanWindow.TurnOn();
        }

        private void HideMenu(LeanWindow leanWindow)
        {
            leanWindow.TurnOff();
            leanWindow.gameObject.SetActive(false);
        }

        private void HandleEnteringInitializationState()
        {
            RegisterObservableListeners();
        }

        private void RegisterObservableListeners()
        {
            MessageBroker.Default.Receive<ExitCurrentMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.MAIN))
                .AddTo(this);
            MessageBroker.Default.Receive<ConnectWalletMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.CONNECT_WALLET))
                .AddTo(this);
            MessageBroker.Default.Receive<MainMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.MAIN))
                .AddTo(this);
            MessageBroker.Default.Receive<EndOfGameMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.END_OF_GAME))
                .AddTo(this);
            MessageBroker.Default.Receive<BankMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.BANK))
                .AddTo(this);
            MessageBroker.Default.Receive<BankDepositMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.BANK_DEPOSIT))
                .AddTo(this);
            MessageBroker.Default.Receive<BankWithdrawMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.BANK_WITHDRAW))
                .AddTo(this);
            MessageBroker.Default.Receive<LoanSharkMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.LOAN_SHARK))
                .AddTo(this);
            MessageBroker.Default.Receive<BuyDrugMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.BUY_DRUG))
                .AddTo(this);
            MessageBroker.Default.Receive<SellDrugMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.SELL_DRUG))
                .AddTo(this);
            MessageBroker.Default.Receive<PubMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.PUB))
                .AddTo(this);
            MessageBroker.Default.Receive<GunsHouseMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.GUNS_HOUSE))
                .AddTo(this);
            MessageBroker.Default.Receive<PoliceFightMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.POLICE_FIGHT))
                .AddTo(this);
            MessageBroker.Default.Receive<InfoMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.INFO))
                .AddTo(this);
            MessageBroker.Default.Receive<HighScoreMenuCalled>()
                .Subscribe(_ => _rootState.ChangeState(Constants.Menus.HIGH_SCORE))
                .AddTo(this);
            _rootState.ChangeState(Constants.Menus.WELCOME_SCREEN);
        }

        #endregion
    }
}
