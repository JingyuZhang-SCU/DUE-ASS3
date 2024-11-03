using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector; // 绑定你的 PlayableDirector
    public Button replayButton;               // 绑定按钮
    public AudioSource clickAudioSource;      // 绑定播放 click 音效的 AudioSource

    private void Start()
    {
        // 确保按钮点击事件绑定到 ReplayTimeline 方法
        if (replayButton != null)
        {
            replayButton.onClick.AddListener(ReplayTimeline);
        }
    }

    public void ReplayTimeline()
    {
        // 播放点击音效
        if (clickAudioSource != null)
        {
            clickAudioSource.Play();
        }

        // 设置 Timeline 从头开始播放
        if (playableDirector != null)
        {
            playableDirector.time = 0;           // 重置到开头
            playableDirector.Play();             // 开始播放
        }
    }
}
