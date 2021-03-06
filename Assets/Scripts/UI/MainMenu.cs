using System;
using System.Collections.Generic;
using System.Linq;
using LotusGangWars.Game;
using LotusGangWars.Utilities;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
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

        private List<GameObject> _allMarketDrugs;
        private List<GameObject> _allInventoryDrugs;

        #endregion





        #region Public Fields

        [Header("SO")]
        public PlayerData PlayerData;
        public GameData GameData;

        [Header("General UI")]
        public Image Panel;
        public RawImage ProfilePicture;
        public TMP_Text UserName;
        
        [Header("Cities")]
        public Button CityOne;
        public Button CityTwo;
        public Button CityThree;
        public Button CityFour;
        public Button CityFive;
        public Button CitySix;
        
        [Header("Stats")]
        public TMP_Text CashValue;
        public TMP_Text GunsValue;
        public TMP_Text HealthValue;
        public TMP_Text DepositValue;
        public TMP_Text DebtValue;
        public TMP_Text DayValue;
        
        [Header("Market")]
        public GameObject AcidView;
        public GameObject HeroinView;
        public GameObject PCPView;
        public GameObject SpeedView;
        public GameObject CocaineView;
        public GameObject LudesView;
        public GameObject PeyoteView;
        public GameObject WeedView;
        public GameObject HashishView;
        public GameObject OpiumView;
        public GameObject ShroomsView;
        public GameObject MDAView;

        [Header("Inventory")]
        public GameObject AcidInventoryView;
        public GameObject HeroinInventoryView;
        public GameObject PCPInventoryView;
        public GameObject SpeedInventoryView;
        public GameObject CocaineInventoryView;
        public GameObject LudesInventoryView;
        public GameObject PeyoteInventoryView;
        public GameObject WeedInventoryView;
        public GameObject HashishInventoryView;
        public GameObject OpiumInventoryView;
        public GameObject ShroomsInventoryView;
        public GameObject MDAInventoryView;

        [Header("Market buttons")] 
        public Button Buy;
        public Button Sell;

        #endregion





        #region Monobehaviour Events

        private void Awake()
        {
            //BUG: kada igrac ima vise para nego sto treba da vrati onda on posalje zelenasu sve pare, a ne samo ono sto duguje
            //BUG: promene cena su lose definisane i lose se ponasaju
            //BUG: srediti prikaz menija
            //TODO: na kraju igre da se sacuva highscore i da se pokaze korisniku
            //NOTE: postoji sansa da ovde ipak mora da se pozove reset values metoda za oba SOa jer ne znam koliko dobro rade njegove interne f-je
            SetInitValues();
            SetButtonInactive();
            RegisterButtonsListeners();
            RegisterOtherListeners();
        }

        private void SetInitValues()
        {
            _allMarketDrugs = new List<GameObject>
            {
                AcidView,
                HeroinView,
                PCPView,
                SpeedView,
                CocaineView,
                LudesView,
                PeyoteView,
                WeedView,
                HashishView,
                OpiumView,
                ShroomsView,
                MDAView
            };
            _allInventoryDrugs = new List<GameObject>
            {
                AcidInventoryView,
                HeroinInventoryView,
                PCPInventoryView,
                SpeedInventoryView,
                CocaineInventoryView,
                LudesInventoryView,
                PeyoteInventoryView,
                WeedInventoryView,
                HashishInventoryView,
                OpiumInventoryView,
                ShroomsInventoryView,
                MDAInventoryView
            };
        }

        private void OnEnable()
        {
            Buy.interactable = false;
            Sell.interactable = false;
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
            Buy.OnClickAsObservable()
                .Subscribe(HandleBuyButtonClick)
                .AddTo(this);
            Sell.OnClickAsObservable()
                .Subscribe(HandleSellButtonClick)
                .AddTo(this);
            Panel.OnPointerClickAsObservable()
                .Subscribe(HandleMainMenuPointerClick)
                .AddTo(this);
        }

        private void HandleMainMenuPointerClick(PointerEventData pointerEventData)
        {
            if (pointerEventData.selectedObject != null)
            {
                var anyMarketDrug = _allMarketDrugs.Any(marketDrug => pointerEventData.selectedObject.Equals(marketDrug));
                if (anyMarketDrug)
                {
                    var selectedDrug = GameData.GameGlobalData.DrugsAtCurrentMarket.First(drug => drug.drugType == pointerEventData.selectedObject.GetComponent<DrugPresenter>().DrugType);
                    PlayerData.Player.SelectedMarketDrug.Value = selectedDrug;
                }
                Buy.interactable = anyMarketDrug;
                var anyInventoryDrug = _allInventoryDrugs.Any(inventoryDrug => pointerEventData.selectedObject.Equals(inventoryDrug));
                if (anyInventoryDrug)
                {
                    var selectedInventoryDrug = PlayerData.Player.InventoryDrugs.First(drug => drug.drugType == pointerEventData.selectedObject.GetComponent<DrugInventoryPresenter>().DrugType);
                    PlayerData.Player.SelectedInventoryDrug.Value = selectedInventoryDrug;
                }
                Sell.interactable = anyInventoryDrug;
            }
            else
            {
                PlayerData.Player.SelectedInventoryDrug.Value = PlayerData.Player.SelectedMarketDrug.Value = null;
                Buy.interactable = false;
                Sell.interactable = false;
            }
        }

        private void HandleCityOneButtonClick(Unit unit)
        {
            PlayerData.Player.CurrentCity = Player.CitiesEnum.Tokyo;
            IncreaseDay();
            SetButtonInactive();
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
            Buy.interactable = false;
            Sell.interactable = false;
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

        private void HandleBuyButtonClick(Unit obj)
        {
            MessageBroker.Default.Publish(new BuyDrugMenuCalled());
        }

        private void HandleSellButtonClick(Unit obj)
        {
            MessageBroker.Default.Publish(new SellDrugMenuCalled());
        }

        private void RegisterOtherListeners()
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
            PlayerData.Player.ObserveEveryValueChanged(player => player.CurrentCity)
                .Subscribe(ObserveCurrentCityChange)
                .AddTo(this);
            PlayerData.Player.InventoryDrugs
                .ObserveAdd()
                .Subscribe(HandleInventoryDrugsAdding)
                .AddTo(this);
            PlayerData.Player.InventoryDrugs
                .ObserveRemove()
                .Subscribe(HandleInventoryDrugsRemoving)
                .AddTo(this);
            PlayerData.Player.UserProfileImage
                .Subscribe(HandleShowingProfilePicture)
                .AddTo(this);
            PlayerData.Player.UserName
                .Subscribe(HandleSettingUserName)
                .AddTo(this);
        }

        private void HandleInventoryDrugsAdding(CollectionAddEvent<IDrug> collectionAddEvent)
        {
            foreach (var inventoryDrug in _allInventoryDrugs.Where(drug => drug.GetComponent<DrugInventoryPresenter>().DrugType == collectionAddEvent.Value.drugType))
            {
                inventoryDrug.SetActive(true);
            }
        }

        private void HandleInventoryDrugsRemoving(CollectionRemoveEvent<IDrug> collectionRemoveEvent)
        {
            foreach (var inventoryDrug in _allInventoryDrugs.Where(drug => drug.GetComponent<DrugInventoryPresenter>().DrugType == collectionRemoveEvent.Value.drugType))
            {
                inventoryDrug.SetActive(false);
            }
        }

        private void HandleShowingProfilePicture(RawImage profilePicture)
        {
            ProfilePicture.texture = profilePicture.texture;
        }

        private void HandleSettingUserName(string userName)
        {
            UserName.SetText(userName);
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
            var highScore = PlayerData.Player.CurrentCash.Value + PlayerData.Player.CurrentDeposit.Value - PlayerData.Player.CurrentDebt.Value;
            PlayerData.Player.AllHighScores.Add(new FloatReactiveProperty(highScore));
            MessageBroker.Default.Publish(new EndOfGameMenuCalled());
        }

        private void ObserveCurrentCityChange(Player.CitiesEnum currentCity)
        {
            GameData.GameGlobalData.DrugsAtCurrentMarket = GameData.GameGlobalData.AllDrugsInAllMarkets[currentCity];
            DisableAllMarketDrugs();
            DisableAllInventoryDrugs();
            GenerateRandomPrices(currentCity);
            EnableMarketDrugPresenters();
            EnableInventoryDrugPresenters();
        }

        private void DisableAllMarketDrugs()
        {
            foreach (var marketDrug in _allMarketDrugs)
            {
                marketDrug.SetActive(false);
            }
        }

        private void DisableAllInventoryDrugs()
        {
            foreach (var inventoryDrug in _allInventoryDrugs)
            {
                inventoryDrug.GetComponent<Selectable>().interactable = false;
            }
        }

        private void GenerateRandomPrices(Player.CitiesEnum currentCity)
        {
            var randomFactor = UnityEngine.Random.Range(GameData.GameGlobalData.PriceFactorsPerMarket[currentCity].Item1, GameData.GameGlobalData.PriceFactorsPerMarket[currentCity].Item2);
            foreach (var drug in GameData.GameGlobalData.DrugsAtCurrentMarket)
            {
                drug.drugPrice.Value *= randomFactor;
            }
        }

        private void EnableMarketDrugPresenters()
        {
            foreach (var marketDrug in from marketDrug in _allMarketDrugs
                from drug in GameData.GameGlobalData.DrugsAtCurrentMarket
                where marketDrug.GetComponent<DrugPresenter>().DrugType == drug.drugType
                select marketDrug)
            {
                marketDrug.SetActive(true);
            }
        }

        private void EnableInventoryDrugPresenters()
        {
            foreach (var inventoryDrug in from inventoryDrug in _allInventoryDrugs
                from drug in GameData.GameGlobalData.DrugsAtCurrentMarket
                where inventoryDrug.GetComponent<DrugInventoryPresenter>().DrugType == drug.drugType
                select inventoryDrug)
            {
                inventoryDrug.GetComponent<Selectable>().interactable = true;
            }
        }

        #endregion
    }
}