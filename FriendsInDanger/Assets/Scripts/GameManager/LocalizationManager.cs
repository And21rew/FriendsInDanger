using UnityEngine;
using UnityEngine.UI;

enum LocalizationButtons
{
    Ru,
    Eng
}

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Button[] localizationButtons;
    [SerializeField] private GameObject ruFlag, engFlag;

    private Image ruFlagImage, engFlagImage;
    private Color white, pressedWhite;

    private void Start()
    {
        InitializeFlags();
        SwitchLanguage();
    }

    private void InitializeFlags()
    {
        white = new Color(1f, 1f, 1f, 1f);
        pressedWhite = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5019608f);
        ruFlagImage = ruFlag.GetComponent<Image>();
        engFlagImage = engFlag.GetComponent<Image>();
    }

    public void Ru()
    {
        string language = "Ru";
        PlayerPrefs.SetString("Language", language);
        SwitchLanguage();
    }

    public void Eng()
    {
        string language = "Eng";
        PlayerPrefs.SetString("Language", language);
        SwitchLanguage();
    }

    private void SwitchLanguage()
    {
        string language = PlayerPrefs.GetString("Language");

        localizationButtons[(int)LocalizationButtons.Ru].interactable = language.Equals("Eng");
        ruFlagImage.color = language.Equals("Ru") ? pressedWhite : white;

        localizationButtons[(int)LocalizationButtons.Eng].interactable = language.Equals("Ru");
        engFlagImage.color = language.Equals("Eng") ? pressedWhite : white;
    }
}