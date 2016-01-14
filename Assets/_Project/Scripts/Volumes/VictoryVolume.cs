using UnityEngine;
using System.Collections;

public class VictoryVolume : MonoBehaviour
{
    private HUD m_HUD;

    void Start()
    {
        m_HUD = GameObject.Find("HUD").GetComponent<HUD>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<Player>())
        {
            m_HUD.DisplayVictory();
        }
    }
}
