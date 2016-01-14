using UnityEngine;
using System.Collections;

public enum DamageType
{
    normal = 0,
    other
}

public struct Damage
{
    public float DamageAmount;
    public DamageType TypeOfDamage;
}

public interface IDamageable
{
    void TakeDamage(GameObject aDamager, Damage aDamage);
}
