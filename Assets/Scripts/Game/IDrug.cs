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
        Drug.DrugTypeEnum drugType { get; }
        FloatReactiveProperty drugPrice { get; }
        IntReactiveProperty drugAmount { get; }
    }
}