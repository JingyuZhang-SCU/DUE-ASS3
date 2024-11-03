using UnityEngine;
using UnityEngine.UI;

public class BGMToggle : MonoBehaviour
{
    public Sprite speakerOnSprite;     // 喇叭开图片
    public Sprite speakerOffSprite;    // 喇叭关图片
    public Button toggleButton;        // 用于控制音效的按钮

    private bool isMuted;

    private void Start()
    {
        // 从 PlayerPrefs 加载静音状态，默认未静音
        isMuted = PlayerPrefs.GetInt("BGM_Muted", 0) == 1;

        // 设置 BGM 的初始静音状态
        BGMManager.Instance.SetMute(isMuted);

        // 更新按钮图片
        UpdateButtonImage();

        // 绑定按钮点击事件
        toggleButton.onClick.AddListener(ToggleBGM);
    }

    private void ToggleBGM()
    {
        // 切换静音状态
        isMuted = !isMuted;

        // 设置 BGM 的静音状态
        BGMManager.Instance.SetMute(isMuted);

        // 保存静音状态
        PlayerPrefs.SetInt("BGM_Muted", isMuted ? 1 : 0);

        // 更新按钮图片
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        // 根据静音状态切换按钮的图片
        toggleButton.image.sprite = isMuted ? speakerOffSprite : speakerOnSprite;
    }
}
