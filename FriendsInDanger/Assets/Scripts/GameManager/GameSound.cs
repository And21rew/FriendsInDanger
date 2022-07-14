using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource[] musicRoots, soundRoots;

    private int musicVolume;
    private int soundVolume;

    private void Awake()
    {
        GetSoundVolume();
    }

    private void Start()
    {
        SetSoundVolume();
    }

    private void GetSoundVolume()
    {
        musicVolume = PlayerPrefs.GetInt("MusicVolume");
        soundVolume = PlayerPrefs.GetInt("SoundVolume");
    }

    private void SetSoundVolume()
    {
        for (int i = 0; i < musicRoots.Length; i++)
            musicRoots[i].volume = (float)musicVolume / 10;

        for (int i = 0; i < soundRoots.Length; i++)
            soundRoots[i].volume = (float)soundVolume / 10;
    }
}