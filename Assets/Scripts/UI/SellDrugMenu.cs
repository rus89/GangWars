using System.Globalization;
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
    public class SellDrugMenu : MonoBehaviour
    {
        #region Private Fields

        private float _drugAmount;

        #endregion





        #region Public Fields

        public PlayerData PlayerData;
        public GameData GameData;
        public Button Sell;
        public Button ExitButton;
        public TMP_InputField DrugAmount;

        #endregion





        #region Monobehaviour Events

        // Start is called before the first frame update
        private void Start()
        {
            //TODO: prikazati samo onu kolicinu koja je dostupna kod igraca
            //TODO: proveriti unos podataka
            //TODO: nakon prodaje povecati kes za amount * cena na trzistu
            //TODO: smanjiti kolicinu droge na trzistu
            RegisterButtonsListeners();
        }

        private void OnEnable()
        {
            _drugAmount = PlayerData.Player.SelectedInventoryDrug.Value.drugAmount.Value;
            DrugAmount.SetTextWithoutNotify(_drugAmount.ToString());
        }

        private void OnDestroy()
        {
            DrugAmount.onValueChanged.RemoveAllListeners();
        }

        private void RegisterButtonsListeners()
        {
            Sell.OnClickAsObservable()
                .Subscribe(HandleSellButtonClick)
                .AddTo(this);
            ExitButton.OnClickAsObservable()
                .Subscribe(_ => MessageBroker.Default.Publish(new ExitCurrentMenuCalled()))
                .AddTo(this);
            DrugAmount.onValueChanged.AddListener(OnValueChanged);
        }

        private void HandleSellButtonClick(Unit obj)
        {
            _drugAmount = float.Parse(DrugAmount.text);
            if (_drugAmount > 0)
            {
                //TODO: ovde treba uporediti selektovanu drogu i njenu trzisnu cenu
                var marketPriceForSelectedInventoryDrug = GameData.GameGlobalData.MarketsDrugs[PlayerData.Player.CurrentCity]
                    .Where(drugType => drugType == PlayerData.Player.SelectedInventoryDrug.Value.drugType);
                PlayerData.Player.CurrentCash.Value += _drugAmount * PlayerData.Player.SelectedInventoryDrug.Value.drugPrice.Value;
                PlayerData.Player.InventoryDrugs.Remove(PlayerData.Player.SelectedInventoryDrug.Value);
            }
            MessageBroker.Default.Publish(new ExitCurrentMenuCalled());
        }

        private void OnValueChanged(string userInput)
        {
            if (userInput.All(char.IsNumber) && !userInput.Equals(string.Empty))
            {
                var userInputFloat = float.Parse(userInput);
                if (userInputFloat < 0f || userInputFloat > _drugAmount)
                {
                    DrugAmount.SetTextWithoutNotify(_drugAmount.ToString());
                }
            }
            else
            {
                DrugAmount.SetTextWithoutNotify("0");
            }
        }

        #endregion
    }
}
