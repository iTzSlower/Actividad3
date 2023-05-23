using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public float timer;
    public float speed = 5;
    public float speedShoot = 3;
    GameObject player;
    Rigidbody rb;
    state a;
    float timerS;
    int repeatShoot = 0;
    enum state
    {
        walk,shoot
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        a = state.walk;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.LookAt(player.transform.position);
        timer += Time.time;
        switch (a)
        {
            case state.walk:
                walk();
                break;
            case state.shoot:
                shoot();
                break;
        }
    }
    void walk()
    {
        Vector3 d = transform.forward;
        rb.velocity = d * speed;

        if(timer > 2)
        {
            a = state.shoot;
            repeatShoot += 1;
            timer = 0;
        }
    }
    void shoot()
    {
        timerS += Time.deltaTime;
        if(timerS > (speedShoot/ repeatShoot))
        {
            Shooting();
            timerS = 0;
        }

        if (timer > 3)
        {
            a = state.walk;
            timer = 0;
        }
    }
    void Shooting()
    {

    }
}
