/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 06/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * 
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

public class DamageVolume : MonoBehaviour
{
    public float TriggerDamagePerSecond;

    void OnTriggerStay(Collider other)
    {
        //Get the players colliding with the trigger...
        if (other.GetComponentInParent<Player>())
        {
            other.GetComponentInParent<Player>().m_PlayerStatistics.CalculateDamage(gameObject, TriggerDamagePerSecond * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //Get the players colliding with the trigger...
        if (other.gameObject.GetComponentInParent<Player>())
        {
            other.gameObject.GetComponentInParent<Player>().m_PlayerStatistics.CalculateDamage(gameObject, TriggerDamagePerSecond * Time.deltaTime);
        }
    }
}
