using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(-Vector3.up*speed);
        if(transform.position.y <-20)
        {
            transform.position = new Vector3(transform.position.x,20,transform.position.z);
        }
    }
}
