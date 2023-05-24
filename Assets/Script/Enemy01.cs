using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public state a;
    public float timer;
    public float speed = 5;
    public GameObject bullet;
    public float speedShoot = 3;
    GameObject player;
    Rigidbody rb;
    float timerS;
    int repeatShoot = 0;
    public enum state
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
        timer += Time.deltaTime;
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
            timer = 0;
            a = state.shoot;
            repeatShoot += 1;
        }
    }
    void shoot()
    {
        rb.velocity = Vector3.zero;
        timerS += Time.deltaTime;
        if(timerS > (speedShoot/ repeatShoot))
        {
            Shooting();
            timerS = 0;
        }

        if (timer > 3)
        {
            timer = 0;
            a = state.walk;
        }
    }
    void Shooting()
    {
        GameObject a = Instantiate(bullet);
        a.transform.position = transform.position + (transform.forward * 1.5f);
        a.transform.rotation = transform.rotation;
        a.GetComponent<EnemyBullet>().speed += (0.5f * repeatShoot);
    }
}
