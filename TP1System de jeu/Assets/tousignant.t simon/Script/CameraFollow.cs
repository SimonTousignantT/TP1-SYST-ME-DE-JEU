using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private float m_offSetY = 34.2f;
    [SerializeField]
    private float m_offSetZ = -79;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(m_player.transform.position.x,m_offSetY, m_offSetZ);
    }
}
