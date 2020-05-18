using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isExplode = false;
    public GameObject ExplosionEffect;
    void OnTriggerEnter(Collider other)
    {
        EnermyHealth enermyHealth = other.gameObject.GetComponent<EnermyHealth>();
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (other.gameObject.tag.Equals("Enermy") && !isExplode)
        {
            if (enermyHealth != null)
                enermyHealth.TakeDamge(20);
            Explode();
            isExplode = true;
        }
        if (other.gameObject.tag.Equals("Player") && !isExplode)
        {
            if (playerHealth != null)
                playerHealth.TakeDamge(20);
            Explode();
            isExplode = true;
        }
    }
    void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);//show explosion
        Destroy(gameObject);//remove bullet
    }
}
