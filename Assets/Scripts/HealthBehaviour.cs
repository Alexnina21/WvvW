using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HealthBehaviour : MonoBehaviour
{
    public UnityEvent<int> ChangeHealth;
    public UnityEvent Dead;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;

    public void Start()
    {
        health = maxHealth;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        ChangeHealth.Invoke(health);
        if (health <= 0)
        {
            Dead.Invoke();
            health = 0;
        }
    }

    public void AddHealth(int h)
    {
        health += h;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        ChangeHealth.Invoke(health);
    }


    public int ReturnHealth()
    {
        return health;
    }

    public int ReturnMaxHealth()
    {
        return maxHealth;
    }

    public void SetHealth()
    {
        health = maxHealth;
    }


}

