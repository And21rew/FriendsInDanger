using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;

    [SerializeField] private GameObject winScreen, pauseScreen, loseScreen;
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private Text score;

    private bool isPause = false;

    private int countItems;
    private int collectedItem = 0;

    private void Awake()
    {
        SetPlayerSkin();
    }

    private void SetPlayerSkin()
    {
        string playerSkin = PlayerPrefs.GetString("PlayerSkin");
        for (int i = 0; i < players.Length; i++)
        {
            if (playerSkin == players[i].name)
            {
                players[i].SetActive(true);
                break;
            }
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        countItems = CountItems();
        UpdateUI();
    }

    private int CountItems()
    {
        return GameObject.FindGameObjectsWithTag("Item").Length;
    }

    public void SetCollectedItem()
    {
        collectedItem++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        score.text = collectedItem + "/" + countItems;

        if (collectedItem == countItems)
            WinLevel();
    }

    public void LoseLevel()
    {
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinLevel()
    {
        Time.timeScale = 0f;

        int progress = PlayerPrefs.GetInt("Progress");
        if (progress < SceneManager.GetActiveScene().buildIndex)
        {
            progress = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("Progress", progress);
        }

        pauseButton.SetActive(false);
        winScreen.SetActive(true);
    }

    public void SwitchPause()
    {
        Time.timeScale = (float)(isPause ? 1 : 0);
        pauseScreen.SetActive(!isPause);
        pauseButton.SetActive(isPause);
        isPause = !isPause;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}