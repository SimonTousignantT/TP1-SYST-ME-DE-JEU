using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private GameObject m_player;
    private float m_plateformPosX;
    private float m_playerPosX;
    [SerializeField]
    private float m_viewDistance = 1000;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        m_plateformPosX = transform.position.x;
        m_playerPosX = m_player.transform.position.x;

        if (m_plateformPosX > m_playerPosX + m_viewDistance)
        {
            Destroy(gameObject);
        }
        if (m_plateformPosX < m_playerPosX - m_viewDistance)
        {
            Destroy(gameObject);
        }
    }
}
