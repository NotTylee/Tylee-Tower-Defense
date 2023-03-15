using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int value = 50;

    [Header("Unity Stuff")]
    public Image healthbar;

    private bool isDead = false;

     void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthbar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += value;

        WaveSpawner.EnemiesAlive--;


        Destroy(gameObject);
    }

   
}
