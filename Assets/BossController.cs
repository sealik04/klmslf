using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public Transform player;
    [SerializeField] float timer = 5;
    private float bulletTime;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float shootSpeed;

    void Update()
    {
        ShootPlayer();
    }

    void ShootPlayer()
    {
        bulletTime -= Time.deltaTime;
        
        if(bulletTime > 0) return;

        bulletTime = timer;
        
        GameObject bulletObj = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward *shootSpeed);
        Destroy(bullet, 5f);
    }
}