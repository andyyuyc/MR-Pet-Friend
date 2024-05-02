using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tsetter : MonoBehaviour
{
    Text m_Text;
    bool Win = false;

    // Start is called before the first frame update
    void Start()
    {

        m_Text = GetComponent<Text>();
    }

    public void SetText()
    {
        if (Win)
        {
            m_Text.text = "You Win!";
        }

        else
        {
            m_Text.text = "You Lose!";
        }

    }
}
