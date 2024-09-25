using System;

public sealed class GameManager
{
    private static readonly Lazy<GameManager> lazy = new Lazy<GameManager>(() => new GameManager());
    public static GameManager instance { get { return lazy.Value; } }

    public PlayerCharacter playerCharacter { get; set; } = null;
    public PlayerState playerState { get; }

    private GameManager()
    {
        playerState = new PlayerState();
    }
}