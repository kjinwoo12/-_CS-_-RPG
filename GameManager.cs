using System;
using System.Collections.Generic;

public sealed class GameManager
{
    private static readonly Lazy<GameManager> lazy = new Lazy<GameManager>(() => new GameManager());
    public static GameManager instance { get { return lazy.Value; } }

    public PlayerCharacter playerCharacter { get; set; } = null;
    public PlayerState playerState { get; }

    public SortedDictionary<int, Mercenary> mercenarySlot { get; }

    private GameManager()
    {
        playerState = new PlayerState();
        mercenarySlot = new SortedDictionary<int, Mercenary>();
        mercenarySlot.Add(0, new Mercenary("빈 슬롯", new CharacterStats(0, 0, 0, 0, 0, 0, 0, 0.0f)));
        mercenarySlot.Add(1, new Mercenary("빈 슬롯", new CharacterStats(0, 0, 0, 0, 0, 0, 0, 0.0f)));
        mercenarySlot.Add(2, new Mercenary("빈 슬롯", new CharacterStats(0, 0, 0, 0, 0, 0, 0, 0.0f)));
    }
}