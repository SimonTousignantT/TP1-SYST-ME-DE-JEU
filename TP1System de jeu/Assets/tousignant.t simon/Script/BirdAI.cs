using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 10;
    private GameObject m_player;
    [SerializeField]
    private float m_destroyDistance = 200;
    [SerializeField]
    private float m_attackRange = 7;
    private float m_detectionOffsetX = -5;
    private bool m_playerDeath = false;
    private float m_dieDropSpeed = -30;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(new Vector2( m_player.transform.position.x,0),new Vector2(transform.position.x,0))>m_destroyDistance )
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(m_speed * -1, 0);
        if (Vector2.Distance(m_player.transform.position, transform.position) < m_attackRange)
        {
         
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position - new Vector3(m_detectionOffsetX * gameObject.GetComponent<Rigidbody2D>().velocity.normalized.x, 0) , new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0), Mathf.Infinity);
            foreach (RaycastHit2D obstacle in hit)
            {
                if (obstacle.collider.tag == "Player")
                {
                    m_player.GetComponent<PlayerMove>().TakeDamage(m_dieDropSpeed);
                    Destroy(gameObject.GetComponent<BoxCollider2D>());
                }
            }
        }
    }
}
