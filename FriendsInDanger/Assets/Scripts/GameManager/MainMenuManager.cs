using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] menuScreens;
    [SerializeField] private Button[] switchSkin;
    [SerializeField] private GameObject[] levelComplete;

    private void Start()
    {
        string playerSkin = PlayerPrefs.GetString("PlayerSkin");
        SwitchPlayerSkin(playerSkin);
        SetCompleteLevel();
    }

    public void SwitchScreens(int index)
    {
        menuScreens[index].SetActive(!menuScreens[index].activeInHierarchy);
    }

    public void EnterInLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void SwitchPlayerSkin(string name)
    {
        PlayerPrefs.SetString("PlayerSkin", name);
        for (int i = 0; i < switchSkin.Length; i++)
        {
            bool isSelected = switchSkin[i].gameObject.name == name;
            switchSkin[i].GetComponent<Animator>().SetBool("isSelected", isSelected);
            switchSkin[i].interactable = !isSelected;
        }
    }

    private void SetCompleteLevel()
    {
        int progress = PlayerPrefs.GetInt("Progress");

        for (int i = 0; i < levelComplete.Length; i++)
            if (progress > i)
                levelComplete[i].SetActive(true);
    }
}
