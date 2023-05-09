using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���ص�PausePanel��
public class PauseControl : MonoBehaviour
{
    public bool EnableAtStart = false;
    private MouseLook mouse;
    private GameObject _child;
    void Start()
    {
        mouse = GameObject.Find("Controller").transform.GetComponentInChildren<MouseLook>();
        _child = transform.GetChild(0).gameObject;
        if(!EnableAtStart) _child.SetActive(false);
        else mouse.UnLockCursor();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _child.SetActive(!_child.activeSelf);
            if(_child.activeSelf)
            {
                mouse.UnLockCursor();
            }
            else
            {
                mouse.LockCursor();
            }
        }
    }

    //��ť�¼�
    public void ContinueGame()
    {
        _child.SetActive(false);
        mouse.LockCursor();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GotoFirstScene()
    {
        SceneManager.LoadScene("Scene1");
    }
}
