using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    new public float speed;
    protected override void Update()
    {
        rb.velocity = transform.forward * speed;
        timer += Time.deltaTime;
        Destroyer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
