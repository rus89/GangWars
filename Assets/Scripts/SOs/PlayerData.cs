using LotusGangWars;
using UnityEngine;

/// <summary>
/// SCENE: /
/// GAME_OBJECT: /
/// DESCRIPTION: Object which saves players data
/// </summary>
[CreateAssetMenu(fileName = nameof(PlayerData))]
public class PlayerData : ScriptableObject
{
    public Player Player;
}