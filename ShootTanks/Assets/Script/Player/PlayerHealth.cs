using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    int maxHealth = 200;
    public int currentHealth;
    bool isDestroy;
    public GameObject ExplosionEffect;
    public PlayerMove playerMove;
    public PlayerShoot playerShoot;
    public Turret turret;

    public HealthBar healthBar;
    public GameObject player;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        playerMove = GetComponent<PlayerMove>();
        playerShoot = GetComponent<PlayerShoot>();
        turret = GetComponent<Turret>();
    }

    public void TakeDamge(int damge)
    {
        if (isDestroy)
        {
            return;
        }
        currentHealth -= damge;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);//show explosion
            PlayerDie();
        }
    }
    void PlayerDie()
    {
        isDestroy = true;
        playerMove.enabled = false;
        playerShoot.enabled = false;
        turret.enabled = false;
    }
}
