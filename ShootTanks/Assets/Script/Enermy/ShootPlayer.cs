using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public GameObject theBullet;
    public Transform spawnBulletPoint;

    public int bulletSpeed;
    public float despawnTime = 1.0f;

    public bool shootAble = true;
    public float reloadTime = 3f;
 
    void Update()
    {
        if (shootAble)
        {
            shootAble = false;
            Shoot();
            StartCoroutine(ShootingYield());
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
