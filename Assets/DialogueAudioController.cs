using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueAudioController : MonoBehaviour
{
    public AudioSource dialogueAudioSource;      // 用于播放 D1 的 AudioSource
    public TextMeshProUGUI dialogueText;         // Dialogue-1 文本对象
    public Image dialogueImage;                  // 要点击的图片对象

    private void Start()
    {
        // 确保 DialogueText 上有点击事件
        if (dialogueText != null)
        {
            dialogueText.gameObject.AddComponent<Button>().onClick.AddListener(PlayDialogueAudio);
        }

        // 确保 DialogueImage 上有点击事件
        if (dialogueImage != null)
        {
            dialogueImage.gameObject.AddComponent<Button>().onClick.AddListener(PlayDialogueAudio);
        }
    }

    public void PlayDialogueAudio()
    {
        if (dialogueAudioSource != null)
        {
            // 如果音频已经在播放，则停止并从头播放
            if (dialogueAudioSource.isPlaying)
            {
                dialogueAudioSource.Stop();
            }

            // 播放音频
            dialogueAudioSource.Play();
        }
    }
}
