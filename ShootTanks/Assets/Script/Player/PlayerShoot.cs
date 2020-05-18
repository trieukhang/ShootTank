using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject theBullet;
    public Transform spawnBulletPoint;

    public int bulletSpeed;
    public float despawnTime = 8.0f;

    public bool shootAble = true;
    private float reloadTime = 1.5f;

    public AudioSource shootingSound;
    private void Start()
    {
        shootingSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (shootAble)
            {
                shootAble = false;
                shootingSound.Play();
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }
    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(reloadTime);
        shootAble = true;
    }
    void Shoot()
    {
        var bullet = Instantiate(theBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, despawnTime);
    }
}
