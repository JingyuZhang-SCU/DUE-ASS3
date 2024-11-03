using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public AudioSource audioSource;  // 音频源
    public AudioClip clickSound;     // 点击音效

    // 跳转到指定页面
    public void FirstPage()
    {
        StartCoroutine(PlaySoundAndSwitchScene(1));
    }

    public void FinalPage()
    {
        StartCoroutine(PlaySoundAndSwitchScene(5));
    }

    public void HomePage()
    {
        StartCoroutine(PlaySoundAndSwitchScene(0));
    }

    // 跳转到上一场景
    public void PreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)  // 检查是否为第一场景
        {
            StartCoroutine(PlaySoundAndSwitchScene(currentSceneIndex - 1));
        }
    }

    // 跳转到下一场景
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)  // 检查是否为最后一场景
        {
            StartCoroutine(PlaySoundAndSwitchScene(currentSceneIndex + 1));
        }
    }

    // 播放音效并切换场景的协程
    private IEnumerator PlaySoundAndSwitchScene(int sceneIndex)
    {
        // 播放音效
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            // 等待音效播放完成
            yield return new WaitForSeconds(clickSound.length);
        }

        // 切换场景
        SceneManager.LoadScene(sceneIndex);
    }
}
