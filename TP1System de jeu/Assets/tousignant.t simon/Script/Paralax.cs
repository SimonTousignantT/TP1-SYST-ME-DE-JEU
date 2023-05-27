using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private Vector2 m_playerPos;
    [SerializeField]
    private GameObject m_ground;
    private float m_groundScale = 200;
    private GameObject m_NewGround;
    private float m_groundOffSetY = 5.9f;

    [SerializeField]
    private float m_nextInvoke = 200;
    [SerializeField]
    private float m_nextInvokeNeg = 200;

   

    // Start is called before the first frame update
    void Start()
    {
        m_nextInvokeNeg = m_nextInvokeNeg * -1;
    }

    // Update is called once per frame
    void Update()
    {
        m_playerPos = transform.position;
       
       
        // si le joueur a parcourue suffisament de chemin en x une plateforme est instancier
        if (m_playerPos.x > m_nextInvoke)
        {
            m_nextInvokeNeg = m_nextInvoke;
            m_nextInvoke += m_groundScale;
             

            m_NewGround = Instantiate(m_ground);
            m_NewGround.transform.position = m_playerPos + new Vector2( m_groundScale, m_groundOffSetY);

        }

        if (m_playerPos.x < m_nextInvokeNeg)
        {
            m_nextInvoke = m_nextInvokeNeg;
            m_nextInvokeNeg += m_groundScale * -1;

            m_NewGround = Instantiate(m_ground);
            m_NewGround.transform.position = m_playerPos + new Vector2( m_groundScale * -1, m_groundOffSetY );

        }

    }
}
