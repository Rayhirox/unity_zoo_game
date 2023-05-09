using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//挂载在交互窗口上
public class WindowControl : MonoBehaviour
{
    public AnimalInfo animalInfo;
    // Update is called once per frame

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) //再次按下E键关闭界面
        {
            animalInfo.MyEnable();
            gameObject.SetActive(false);
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
