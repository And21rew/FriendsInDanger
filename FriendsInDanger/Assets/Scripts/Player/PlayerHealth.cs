using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameManager gameManager;

    private int health = CharacterConstant.GetHealthPlayer();

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void RecountHealth(int changeHealth)
    {
        health += changeHealth;
        CheckLive();
    }

    private void CheckLive()
    {
        if (health <= 0)
        {
            gameManager.GetComponent<GameManager>().LoseLevel();
        }
    }
}
