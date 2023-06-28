using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawer : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    private float m_chronos = 0;
    [SerializeField]
    private float m_birdTimerSpawn = 10;
    [SerializeField]
    private GameObject m_bird;
    [SerializeField]
    private Vector3 m_spawnOffset = new Vector3(200, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_chronos += Time.deltaTime;
        if(m_chronos > m_birdTimerSpawn)
        {
            m_chronos = 0;
            Instantiate(m_bird).transform.position = m_player.transform.position + m_spawnOffset;
        }
    }
}
