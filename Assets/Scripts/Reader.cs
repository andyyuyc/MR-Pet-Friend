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
        // ��¼��ʼ�ı�����
        previousText = textToMonitor.text;
    }

    private void Update()
    {
        // ������ı���֮ǰ���ı���ͬ���򴥷���ť����¼�
        if (textToMonitor.text != previousText)
        {
            buttonToClick.onClick.Invoke();
            previousText = textToMonitor.text;
        }
    }
}
