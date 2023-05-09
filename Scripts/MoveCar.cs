using UnityEngine;
using System.Collections;
public class MoveCar : MonoBehaviour
{
    public GameObject BRWheel;     	//声明游戏对象变量，用来获取挂有车轮碰撞器的对象
    public GameObject BLWheel;     	//获取两个车轮同时驱动车辆
    public float torque;                	//声明floa类型变量，用于设置力矩的大小
    void FixedUpdate()
    {
        BRWheel.GetComponent<WheelCollider>().motorTorque = torque; 	//获取车轮碰撞器
        BLWheel.GetComponent<WheelCollider>().motorTorque = torque;	// 并为引擎转矩变量赋值
    }
}
