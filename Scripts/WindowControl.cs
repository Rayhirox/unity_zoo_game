using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ڽ���������
public class WindowControl : MonoBehaviour
{
    public AnimalInfo animalInfo;
    // Update is called once per frame

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) //�ٴΰ���E���رս���
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
