using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRetreat : MonoBehaviour
{
    private float m_chronos = 0;
    [SerializeField]
    private float m_timerSpeed = 0.1f;
    [SerializeField]
    private float m_speed2 = 1.1f;
    private bool m_gameWin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         m_chronos += Time.deltaTime;
         if (m_chronos > m_timerSpeed)
         {
             m_chronos = 0;
             gameObject.transform.localScale = gameObject.transform.localScale / m_speed2;
         }
    }
}
