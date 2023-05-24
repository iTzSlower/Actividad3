using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    public int life = 1;
    public GameObject bullet;
    public float speed;
    public float radius = 2.5f;

    GameObject player;
    Rigidbody rb;
    bool retroceder = true;
    float bullettimer;
    float maxtimer = 2.5f;
    int repeatShoot = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        bullettimer += Time.deltaTime;
        if (bullettimer > maxtimer)
        {
            repeatShoot += 1;
            life += 1;
            Shoot();
            bullettimer = 0;
        }
    }
    void Move()
    {
        RaycastHit hit;
        transform.LookAt(player.transform.position);

        if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, radius/2))
        {
            rb.velocity = (transform.forward * -1) * speed;
            retroceder = false;
        }
        else
        {
            retroceder = true;
        }
    }
    private void OnDrawGizmos()
    {

        if (retroceder)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Shoot()
    {
        GameObject a = Instantiate(bullet);
        a.transform.position = transform.position + (transform.forward * 1.5f * (0.5f * repeatShoot));
        a.transform.rotation = transform.rotation;
        a.GetComponent<Transform>().localScale += ((Vector3.one/2) * repeatShoot);
    }
}
