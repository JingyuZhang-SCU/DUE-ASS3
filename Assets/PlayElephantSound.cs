using UnityEngine;

public class PlayElephantSound : MonoBehaviour
{
    public AudioSource audioSource;

    // 这个方法会在按钮点击时调用
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
