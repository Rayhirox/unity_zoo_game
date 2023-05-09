using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundDetection : MonoBehaviour
{
    public bool jumpOptimation;
    public bool Movable = true;
    public bool enableTurn = true;
    public int Hungriness
    {
        get => _hungriness;
        set => _hungriness = Mathf.Clamp(value, 0, 100);
    }
    private int _hungriness;
    private float turnTime = 3f;
    private float _Time;
    private Vector3 origin;
    private Ray ray;

    private int layerMask;
    private RaycastHit[] hits;
    private Animator _animator;
    private float _hungryTime;

    void Start()
    {
        jumpOptimation = false;
        origin = transform.position;
        //向下检测
        ray = new Ray(origin, -Vector3.up);
        layerMask = LayerMask.GetMask("Ground");

        //动画相关
        _animator = GetComponent<Animator>();
        _animator.SetBool(0, Movable);
        int r = Random.Range(0, 3);
        _animator.SetInteger("Behavior", r);
        r = Random.Range(0, 359);
        transform.rotation = Quaternion.Euler(0, r, 0);

        //随机一个旋转时间
        turnTime = Random.Range(7f, 12f);

        //饥饿
        _hungryTime = 0;
        Hungriness = Random.Range(70, 100);
    }

    private void Update()
    {

        if (!enableTurn) return;
        
        _Time += Time.deltaTime;
        _hungryTime += Time.deltaTime;
        if(_hungryTime > 5f) //饥饿
        {
            _hungryTime = 0f;
            Hungriness -= Random.Range(1, 4);
            if(Hungriness == 0)
            {
                gameObject.SetActive(false);
            }
        }
        if(_Time > turnTime) //转向
        {
            _Time = 0f;
            Vector3 endValue = new Vector3(0, Random.Range(-90, 90), 0);
            transform.DOLocalRotate(endValue, 1.5f);
        }
    }

    private void FixedUpdate()
    {
        origin = transform.position;
        ray.origin = origin;
        hits = Physics.RaycastAll(ray, Mathf.Infinity, layerMask);
        //如果检测不到说明陷下去了
        if(hits.Length == 0)
        {
            transform.position += new Vector3(0f, 0.01f, 0f);
        }
        else
        {
            if (jumpOptimation) return;

            if (hits[0].distance > 0.05f)
            {
                 transform.position -= new Vector3(0f, hits[0].distance - 0.02f, 0f);
            }
        }
    }

    public void ResetTimeCount()
    {
        _Time = 0f;
    }
}
