/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 13/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * 
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour, IWeapon
{
    private GameObject m_Wielder; // character wielding the weapon. Probably should have a character interface
    // Or maybe the player and other humanoid characters will inherit from a class which supports holding items...
    private GameObject m_Target;
    private IEnumerator coroutine;

    private Damage m_Damage;
    private bool CanDamage;

    public float m_DamageAmount;
    public DamageType m_TypeOfDamage;

    public float m_CycleSpeed;
    private Vector3 m_TranslateStart;
    private Vector3 m_Offset;
    public Vector3 m_TranslateEnd = new Vector3();

    void Start()
    {
        m_TranslateStart = transform.localPosition;
        m_TranslateEnd = m_TranslateStart + m_TranslateEnd;
        m_Offset = m_TranslateEnd - m_TranslateStart;
        //m_DamageZone.enabled = false;

        coroutine = Translate_cr();
        SetDamage();
    }

    private void SetDamage()
    {
        m_Damage.DamageAmount = m_DamageAmount;
        m_Damage.TypeOfDamage = m_TypeOfDamage;
    }

    void OnCollisionEnter(Collision other) // When player hits attack the collider should be enabled for the duration of the animation
    {
        //Cheap way would be to disable the collider once it hits one damageable thing
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            if (CanDamage)
            {
                DealDamage(other);
            }
        }
        else
        {
            //Play collision animation...
        }
    }

    public void Attack() // call by player when they attack
    {
        //m_DamageZone.enabled = true;
        //Start anim/translation...
        Activate();
    }

    public void Activate()
    {
        if(coroutine == null)
        {
            coroutine = Translate_cr();
        }
        StartCoroutine(coroutine);
    }

    public void DeActivate()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator Translate_cr()
    {
        m_TranslateStart = transform.localPosition;
        m_TranslateEnd = m_TranslateStart + m_Offset;
        float percent = 0;
        CanDamage = true;
        float timer = 0.0f;

        while (percent < 0.99)
        {
            percent = (Mathf.Cos(timer  * m_CycleSpeed * Mathf.PI+ (Mathf.PI )) + 1.0f) / 2.0f;
            transform.localPosition = Vector3.Lerp(m_TranslateStart, m_TranslateEnd, percent);
            timer += Time.deltaTime;

            yield return null;
        }
        while (percent > 0.01)
        {
            CanDamage = false;
            percent = (Mathf.Cos(timer * m_CycleSpeed * Mathf.PI + (Mathf.PI)) + 1.0f) / 2.0f;

            transform.localPosition = Vector3.Lerp(m_TranslateStart, m_TranslateEnd, percent);
            timer += Time.deltaTime;


            yield return null;
        }
        transform.localPosition = Vector3.zero;
        coroutine = null;
    }

    public void DealDamage(Collision aTarget)
    {
        aTarget.gameObject.GetComponent<IDamageable>().TakeDamage(m_Target, m_Damage);
    }
}
