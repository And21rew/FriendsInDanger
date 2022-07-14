using UnityEngine;
using UnityEngine.UI;

public class TextLanguage : MonoBehaviour
{
    private string language;
    private Text text;

    [SerializeField] private string textRu;
    [SerializeField] private string textEng;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        language = PlayerPrefs.GetString("Language");

        if (language == "" || language == "Eng")
            text.text = textEng;
        else if (language == "Ru")
            text.text = textRu;
    }
}