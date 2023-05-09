using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public GameObject Car;
    public BoxCollider Collider1;
    public BoxCollider Collider2;
    public Cloth Flag;

    private MoveCar moveCar;
    private BoxCollider carCollider;
    void Start()
    {
        moveCar = Car.GetComponent<MoveCar>();
        carCollider = Car.GetComponent<BoxCollider>();
        moveCar.torque = 0;
    }


    //ÆôÍ£³µÁ¾
    public void CarSwitch()
    {
        if(moveCar.torque > 0)
        {
            moveCar.torque = 0;
        }
        else moveCar.torque = 1500;
    }

    //Åö×²¹ýÂË
    public void ColliderSwitch1()
    {
        if(Physics.GetIgnoreCollision(carCollider, Collider1))
            Physics.IgnoreCollision(carCollider, Collider1, false);
        else Physics.IgnoreCollision(carCollider, Collider1, true);
    }

    public void ColliderSwitch2()
    {
        if (Physics.GetIgnoreCollision(carCollider, Collider2))
            Physics.IgnoreCollision(carCollider, Collider2, false);
        else Physics.IgnoreCollision(carCollider, Collider2, true);
    }

    //·ç´µÆì×Ó
    public void FlagSwitch()
    {
        if(Flag.externalAcceleration.z == 0) { Flag.externalAcceleration = new Vector3(0, 0, -50); Flag.randomAcceleration = new Vector3(0, 30, 0); }
        else { Flag.externalAcceleration = new Vector3(0, 0, 0); Flag.randomAcceleration = new Vector3(0, 0, 0); }
        
    }
}
