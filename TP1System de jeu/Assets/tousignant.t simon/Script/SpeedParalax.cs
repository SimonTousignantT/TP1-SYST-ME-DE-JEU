using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParalax : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    private GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(m_player.GetComponent<Rigidbody2D>().velocity.x / m_speed, 0);
    }
}
