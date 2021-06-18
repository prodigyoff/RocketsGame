using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 0;
    [SerializeField] private int healthPoints = 0;
    public UnityEvent onDestroyed;

    public float MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }

    public int HealthPoints
    {
        get => healthPoints;
        set => healthPoints = value;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int value)
    {
        healthPoints -= value;
        if (healthPoints <= 0)
        {
            Die();
            onDestroyed.Invoke();
            onDestroyed.RemoveAllListeners();
        }
    }
}
