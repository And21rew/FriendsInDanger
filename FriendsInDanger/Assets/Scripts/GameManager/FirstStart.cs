using UnityEngine;

public class FirstStart : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("PlayerSkin"))
            PlayerPrefs.SetString("PlayerSkin", "PinkMan");

        if (!PlayerPrefs.HasKey("Progress"))
            PlayerPrefs.SetInt("Progress", 0);

        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetInt("MusicVolume", 5);

        if (!PlayerPrefs.HasKey("SoundVolume"))
            PlayerPrefs.SetInt("SoundVolume", 5);

        if (!PlayerPrefs.HasKey("Language"))
            PlayerPrefs.SetString("Language", "Eng");
    }
}
