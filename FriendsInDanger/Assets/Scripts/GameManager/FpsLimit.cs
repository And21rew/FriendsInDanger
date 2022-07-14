using UnityEngine;

public class FpsLimit : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = CharacterConstant.GetFrameLimit();
    }
}
