using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDoll : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float Damage;

    protected abstract void TakeDamage(int damage);

    protected abstract float ConvertHealthToPercante();
}

