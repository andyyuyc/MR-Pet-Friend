using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ts : MonoBehaviour
{
    Text m_Text;

    // Start is called before the first frame update
    void Start()
    {

        m_Text = GetComponent<Text>();
    }

    public void SetText(string text)
    {
        m_Text.text = text;
    }
}
