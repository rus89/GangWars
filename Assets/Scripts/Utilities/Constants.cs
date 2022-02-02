using RSG;

namespace LotusGangWars.Utilities
{
    /// <summary>
    /// SCENE: /
    /// GAME_OBJECT: /
    /// DESCRIPTION: Native class that holds game related constants
    /// </summary>
    public static class Constants
    {
        public static class Menus
        {
            internal const string WELCOME_SCREEN = nameof(WELCOME_SCREEN);
            internal const string CONNECT_WALLET = nameof(CONNECT_WALLET);
            internal const string MAIN = nameof(MAIN);
            internal const string END_OF_GAME = nameof(END_OF_GAME);
            internal const string BANK = nameof(BANK);
            internal const string BANK_DEPOSIT = nameof(BANK_DEPOSIT);
            internal const string BANK_WITHDRAW = nameof(BANK_WITHDRAW);
            internal const string LOAN_SHARK = nameof(LOAN_SHARK);
            internal const string BUY_DRUG = nameof(BUY_DRUG);
            internal const string SELL_DRUG = nameof(SELL_DRUG);
            internal const string PUB = nameof(PUB);
            internal const string GUNS_HOUSE = nameof(GUNS_HOUSE);
            internal const string POLICE_FIGHT = nameof(POLICE_FIGHT);
            internal const string INFO = nameof(INFO);
            internal const string HIGH_SCORE = nameof(HIGH_SCORE);
        }
        
        public static class MenusStatesNames
        {
            internal const string INITIALIZATION = nameof(INITIALIZATION);
            internal const string SHOWN = nameof(SHOWN);
            internal const string HIDDEN = nameof(HIDDEN);
        }
        
        public static class MenusStatesTypes
        {
            public class Normal : AbstractState {}
        }
        
        public static class StringFormats
        {
            internal const string CURRENCY_FORMAT = "C";
            internal const string DIGITS_FORMAT = "D0";
            internal const string NUMBER_FORMAT = "N2";
        }
    }
}
