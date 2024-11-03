using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;  // 单例模式，确保只存在一个 BGMManager 实例

    private AudioSource audioSource;

    private void Awake()
    {
        // 如果已经有一个 BGMManager 实例存在，则销毁当前对象，避免重复播放
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 将当前实例设置为单例，并防止它在场景切换时被销毁
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        // 确保 BGM 在游戏开始时播放
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void SetMute(bool isMuted)
    {
        audioSource.mute = isMuted;
    }

    public bool IsMuted()
    {
        return audioSource.mute;
    }
}
