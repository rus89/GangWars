using LotusGangWars;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameData))]
public class GameData : ScriptableObject
{
    public GameGlobalData GameGlobalData;

    private void OnEnable()
    {
        GameGlobalData.ResetValues();
    }

    private void OnDisable()
    {
        GameGlobalData.ResetValues();
    }
}