using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem explosion;
    private bool hasEnter;
    void Start()
    {
        hasEnter = false;
        explosion.Pause();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if(!hasEnter) explosion.Play();
        hasEnter = true;
    }
}
