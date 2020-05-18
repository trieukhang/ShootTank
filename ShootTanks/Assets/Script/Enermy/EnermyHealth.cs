using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnermyHealth : MonoBehaviour
{ 
    public int maxHealth;
    public int currentHealth;
    public int scoreValue = 10;
    bool isDestroy;
    public GameObject ExplosionEffect;

    public HealthBar healthBar;
    public GameObject enermy;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
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
            EnermyDestroy();
        }
    }
    void EnermyDestroy()
    {
        isDestroy = true;
        Destroy(enermy);
        Score.score += scoreValue;
        SpawnEnemy.instance.SpawnTank();
    }
}
