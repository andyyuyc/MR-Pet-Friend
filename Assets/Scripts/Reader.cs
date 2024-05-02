using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AutoClickButton : MonoBehaviour
{
    public TextMeshProUGUI textToMonitor;
    public Button buttonToClick;

    private string previousText = "";

    private void Start()
    {
        // 记录初始文本内容
        previousText = textToMonitor.text;
    }

    private void Update()
    {
        // 如果新文本和之前的文本不同，则触发按钮点击事件
        if (textToMonitor.text != previousText)
        {
            buttonToClick.onClick.Invoke();
            previousText = textToMonitor.text;
        }
    }
}
