using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour
{
    public float rayDistance = 7f;
    private Ray ray;
    private int layerMask;
    private Transform target;
    public AnimalInfo _animalInfo;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Animals", "Lights");
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 从屏幕鼠标位置发射一条射线
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, layerMask))
        {
            target = FindTopParent(hit.transform);
            _animalInfo.Activate(target.gameObject);
        }
        else
        {
            _animalInfo.Inactivate();
        }
    }

    private Transform FindTopParent(Transform transform)
    {
        while (transform.parent != null && transform.parent.gameObject.name != "Animals")
        {
            transform = transform.parent;
        }
        return transform;
    }
}
