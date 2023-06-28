using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject m_enemie;
    private GameObject m_player;
    private Vector3 m_flag;
    [SerializeField]
    private float m_spawnOffsetX = 20;
    [SerializeField]
    private float m_distanceBetweenEnemie = 10;
    [SerializeField]
    private float m_mapLenght = 600;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_flag = m_player.transform.position + new Vector3(m_spawnOffsetX,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_player.transform.position.x > m_flag.x)
        {
            if (m_player.transform.position.x < m_mapLenght)
            {
                m_flag += new Vector3(m_distanceBetweenEnemie, 0, 0);
                Instantiate(m_enemie).transform.position = m_flag;
            }
        }
    }
}
