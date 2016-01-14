using UnityEngine;
using System.Collections;

public class DestrucibleWall : MonoBehaviour, IDamageable
{
    public float m_Health = 1;

    public void TakeDamage(GameObject aDamager, Damage aDamage)
    {
        switch (aDamage.TypeOfDamage)
        {
            case DamageType.normal:
                if (m_Health > 0)
                {
                    m_Health -= aDamage.DamageAmount;
                }
                else
                {
                    m_Health = 0;
                    gameObject.SetActive(false);
                }
                break;
            case DamageType.other:
                if (m_Health > 0)
                {
                    m_Health -= aDamage.DamageAmount;
                }
                else
                {
                    m_Health = 0;
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
