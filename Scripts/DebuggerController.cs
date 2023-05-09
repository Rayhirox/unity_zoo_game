using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerController : MonoBehaviour
{
    public GameObject window;
    private bool _isActive;
    void Start()
    {
        window.SetActive(false);
        _isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            _isActive = !_isActive;
            Debug.Log(_isActive);
        }
        if(_isActive)
        {
            window.SetActive(true);
        }
        else window.SetActive(false);
    }
}
