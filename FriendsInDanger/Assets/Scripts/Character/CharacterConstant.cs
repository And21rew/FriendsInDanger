using UnityEngine;

public class CharacterConstant : MonoBehaviour
{
    //
    // Animation
    //
    public enum Animation
    {
        Stay,
        Run,
        Jump
    }

    //
    // Game settings
    //
    private static readonly int frameLimit = 60;

    public static int GetFrameLimit()
    {
        return frameLimit;
    }

    //
    // Player
    //
    private static readonly int healthPlayer = 1;
    private static readonly float speedPlayer = 4f;
    private static readonly float forceJumpPlayer = 7f;

    public static int GetHealthPlayer()
    {
        return healthPlayer;
    }

    public static float GetSpeedPlayer()
    {
        return speedPlayer;
    }

    public static float GetForceJumpPlayer()
    {
        return forceJumpPlayer;
    }

    //
    // Enemys
    //
    private static readonly int healthEnemyBunny; // NEED
    private static readonly float speedEnemyBunny = 1.5f;

    private static readonly float speedEnemySaw = 2f;

    public static int GetHealthEnemyBunny() // NEED
    {
        return healthEnemyBunny;
    }

    public static float GetSpeedEnemyBunny()
    {
        return speedEnemyBunny;
    }

    public static float GetSpeedEnemySaw()
    {
        return speedEnemySaw;
    }
}
