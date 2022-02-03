using UniRx;

namespace LotusGangWars.Game
{
    /// <summary>
    /// SCENE: /
    /// GAME_OBJECT: /
    /// DESCRIPTION: Interface for sharing information between drug types
    /// </summary>
    public interface IDrug
    {
        //TODO: cena droge se razlikuje od trzista do trzista, a zatim i od dogadjaja na odredjenom trzistu do dogadjaja tako da mislim da bi ovo trebalo da bude dictionary i da kljucevi budu trzista, a vrednosti cene
        //medjutim, to mozda i ne treba da se cuva u samoj drogi, nego u podacima o trzistu zato sto je cena uvek cena bez obzira na sve
        //spoljasnji faktori su ti koji uticu na cenu
        Drug.DrugTypeEnum drugType { get; }
        FloatReactiveProperty drugPrice { get; }
        IntReactiveProperty drugAmount { get; }
    }
}