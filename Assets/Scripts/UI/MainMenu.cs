using System;
using LotusGangWars.Utilities;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace LotusGangWars.UI
{
    /// <summary>
    /// SCENE: Main
    /// GAME_OBJECT: MainMenu
    /// DESCRIPTION: Class that controls Main Menu
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        #region Private Fields

        

        #endregion





        #region Public Fields

        [Header("SO")]
        public PlayerData PlayerData;
        public GameData GameData;

        [Header("UI")]
        public Button CityOne;
        public Button CityTwo;
        public Button CityThree;
        public Button CityFour;
        public Button CityFive;
        public Button CitySix;
        public TMP_Text CashValue;
        public TMP_Text GunsValue;
        public TMP_Text HealthValue;
        public TMP_Text DepositValue;
        public TMP_Text DebtValue;
        public TMP_Text DayValue;

        #endregion





        #region Monobehaviour Events

        private void Awake()
        {
            PlayerData.Player.ResetValues();
            GameData.GameGlobalData.ResetValues();
            SetButtonInactive();
            RegisterButtonsListeners();
            RegisterPlayerDataListeners();
            //TODO: na kraju igre da se sacuva highscore i da se pokaze korisniku
            //BUG: ako je zadnji grad tokyo ne prekida se igra
        }

        // Start is called before the first frame update
        private void Start()
        {
            
        }

        private void RegisterButtonsListeners()
        {
            CityOne.OnClickAsObservable()
                .Subscribe(HandleCityOneButtonClick)
                .AddTo(this);
            CityTwo.OnClickAsObservable()
                .Subscribe(HandleCityTwoButtonClick)
                .AddTo(this);
            CityThree.OnClickAsObservable()
                .Subscribe(HandleCityThreeButtonClick)
                .AddTo(this);
            CityFour.OnClickAsObservable()
                .Subscribe(HandleCityFourButtonClick)
                .AddTo(this);
            CityFive.OnClickAsObservable()
                .Subscribe(HandleCityFiveButtonClick)
                .AddTo(this);
            CitySix.OnClickAsObservable()
                .Subscribe(HandleCitySixButtonClick)
                .AddTo(this);
        }
        
        private void HandleCityOneButtonClick(Unit unit)
        {
            PlayerData.Player.CurrentCity = Player.CitiesEnum.Tokyo;
            IncreaseDay();
            SetButtonInactive();
            //TODO: nakon sto zavrsi to ili ne uradi nista, pojavljuje se home menu u kome su prikazane sve dostupne droge za taj grad
        }

        private void HandleCityTwoButtonClick(Unit unit)
        {
            PlayerData.Player.CurrentCity = Player.CitiesEnum.Delphi;
            IncreaseDay();
            SetButtonInactive();
        }
        
        private void HandleCityThreeButtonClick(Unit unit)
        {
            PlayerData.Player.CurrentCity = Player.CitiesEnum.Shanghai;
            IncreaseDay();
            SetButtonInactive();
        }
        
        private void HandleCityFourButtonClick(Unit unit)
        {
            PlayerData.Player.CurrentCity = Player.CitiesEnum.Bangkok;
            IncreaseDay();
            SetButtonInactive();
        }
        private void HandleCityFiveButtonClick(Unit unit)
        {
            PlayerData.Player.CurrentCity = Player.CitiesEnum.Manila;
            IncreaseDay();
            SetButtonInactive();
        }

        private void HandleCitySixButtonClick(Unit unit)
        {
            PlayerData.Player.CurrentCity = Player.CitiesEnum.Seoul;
            IncreaseDay();
            SetButtonInactive();
        }

        private void IncreaseDay()
        {
            GameData.GameGlobalData.CurrentDay.Value++;
        }

        private void SetButtonInactive()
        {
            switch (PlayerData.Player.CurrentCity)
            {
                case Player.CitiesEnum.Tokyo:
                    CityTwo.interactable = CityThree.interactable = CityFour.interactable = CityFive.interactable = CitySix.interactable = true;
                    CityOne.interactable = false;
                    break;
                case Player.CitiesEnum.Delphi:
                    CityOne.interactable = CityThree.interactable = CityFour.interactable = CityFive.interactable = CitySix.interactable = true;
                    CityTwo.interactable = false;
                    break;
                case Player.CitiesEnum.Shanghai:
                    CityOne.interactable = CityTwo.interactable = CityFour.interactable = CityFive.interactable = CitySix.interactable = true;
                    CityThree.interactable = false;
                    break;
                case Player.CitiesEnum.Bangkok:
                    CityOne.interactable = CityTwo.interactable = CityThree.interactable = CityFive.interactable = CitySix.interactable = true;
                    CityFour.interactable = false;
                    break;
                case Player.CitiesEnum.Manila:
                    CityOne.interactable = CityTwo.interactable = CityThree.interactable = CityFour.interactable = CitySix.interactable = true;
                    CityFive.interactable = false;
                    break;
                case Player.CitiesEnum.Seoul:
                    CityOne.interactable = CityTwo.interactable = CityThree.interactable = CityFour.interactable = CityFive.interactable = true;
                    CitySix.interactable = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RegisterPlayerDataListeners()
        {
            PlayerData.Player.CurrentCash
                .Subscribe(HandlePlayerCashChange)
                .AddTo(this);
            PlayerData.Player.CurrentGuns
                .Subscribe(HandlePlayerGunsChange)
                .AddTo(this);
            PlayerData.Player.CurrentHealth
                .Subscribe(HandlePlayerHealthChange)
                .AddTo(this);
            PlayerData.Player.CurrentDeposit
                .Subscribe(HandlePlayerDepositChange)
                .AddTo(this);
            PlayerData.Player.CurrentDebt
                .Subscribe(HandlePlayerDebtChange)
                .AddTo(this);
            GameData.GameGlobalData.CurrentDay
                .Subscribe(HandleCurrentDayChange)
                .AddTo(this);
            GameData.GameGlobalData.CurrentDay
                .Where(day => day > 31)
                .Subscribe(HandleEndOfGame)
                .AddTo(this);
        }

        private void HandlePlayerCashChange(float currentCash)
        {
            CashValue.SetText(currentCash.ToString(Constants.StringFormats.CURRENCY_FORMAT));
        }

        private void HandlePlayerGunsChange(int currentGuns)
        {
            GunsValue.SetText(currentGuns.ToString(Constants.StringFormats.DIGITS_FORMAT));
        }

        private void HandlePlayerHealthChange(int currentHealth)
        {
            HealthValue.SetText(currentHealth.ToString(Constants.StringFormats.DIGITS_FORMAT));
        }

        private void HandlePlayerDepositChange(float currentDeposit)
        {
            DepositValue.SetText(currentDeposit.ToString(Constants.StringFormats.CURRENCY_FORMAT));
            DepositValue.color = currentDeposit > 0f ? Color.green : Color.white;
        }

        private void HandlePlayerDebtChange(float currentDebt)
        {
            DebtValue.SetText(currentDebt.ToString(Constants.StringFormats.CURRENCY_FORMAT));
            DebtValue.color = currentDebt > 0f ? Color.red : Color.white;
        }

        private void HandleCurrentDayChange(int currentDay)
        {
            DayValue.SetText(currentDay.ToString(Constants.StringFormats.DIGITS_FORMAT));
            if (currentDay > 1 && currentDay <= 31)
            {
                if (PlayerData.Player.CurrentDebt.Value > 0)
                {
                    PlayerData.Player.CurrentDebt.Value += PlayerData.Player.CurrentDebt.Value * GameData.GameGlobalData.DebtInterestRate.Value;
                }
                if (PlayerData.Player.CurrentDeposit.Value > 0)
                {
                    PlayerData.Player.CurrentDeposit.Value += PlayerData.Player.CurrentDeposit.Value * GameData.GameGlobalData.DepositInterestRate.Value;
                }

                HandleShowingMenus();
            }
        }

        private void HandleShowingMenus()
        {
            //TODO: dodati menije kasnije
            switch (PlayerData.Player.CurrentCity)
            {
                case Player.CitiesEnum.Tokyo:
                    MessageBroker.Default.Publish(new LoanSharkMenuCalled());
                    break;
                case Player.CitiesEnum.Delphi:
//                    MessageBroker.Default.Publish(new GunsHouseMenuCalled());
                    break;
                case Player.CitiesEnum.Shanghai:
                    break;
                case Player.CitiesEnum.Bangkok:
                    break;
                case Player.CitiesEnum.Manila:
                    break;
                case Player.CitiesEnum.Seoul:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HandleEndOfGame(int obj)
        {
            PlayerData.Player.ResetValues();
            GameData.GameGlobalData.ResetValues();
            MessageBroker.Default.Publish(new EndOfGameMenuCalled());
        }

        #endregion
    }
}