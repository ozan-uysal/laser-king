using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fireBullet;
    public Player player;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(player.isFire)
                Instantiate(fireBullet, transform.position, Quaternion.identity);
            else
                Instantiate(bullet,transform.position,Quaternion.identity); 
        }
    }
}
