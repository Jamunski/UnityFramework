/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 13/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * Needs to be structured in such a way that abilities can be changed and calls to them will remain
 * the same...
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    private PlayerStatistics m_Stats;
    private IWeapon m_Weapon;

    void Start()
    {
        m_Stats = GetComponent<Player>().m_PlayerStatistics;
        m_Weapon = GetComponentInChildren<IWeapon>();
    }

    public void Jump()
    {
        Debug.Log(gameObject.name + ": Jumping");
    }

    public void Sprint()
    {
        m_Stats.m_IsSprinting = true;
        m_Stats.CalculateSpeed();
    }

    public void Attack()
    {
        if (m_Weapon != null)
        {
            m_Weapon.Attack();
            return;
        }
        Debug.Log(gameObject.name + ": WeaponNull");
    }

    public void Magic()
    {
        Debug.Log(gameObject.name + ": Magic");
    }
}
