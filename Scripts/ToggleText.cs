using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour
{
    private string origin;
    public Text m_text;
    // Start is called before the first frame update
    void Start()
    {

        origin = m_text.text;
    }

    public void Toggle(string text)
    {
        if(text != m_text.text)
        {
            m_text.text = text;
        }
        else m_text.text = origin;
    }
}
