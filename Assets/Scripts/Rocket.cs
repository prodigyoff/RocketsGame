using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float flySpeed = 0;
    [SerializeField] private int damage = 0;
    [SerializeField] private float distanceToExplode = 0;

    public float FlySpeed
    {
        get => flySpeed;
        set => flySpeed = value;
    }

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public float DistanceToExplode
    {
        get => distanceToExplode;
        set => distanceToExplode = value;
    }

    public void DealDamage(int value, Player player)
    {
        player.TakeDamage(value);
    }
}
