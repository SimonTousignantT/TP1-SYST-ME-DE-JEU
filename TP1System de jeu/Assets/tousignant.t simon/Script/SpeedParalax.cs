using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParalax : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    private GameObject m_player;
    private bool m_ZoneCollide = false;
    private bool m_playerDead = false;
    private float m_distanceRight;
    private float m_distanceLeft;
    private float m_raycastOffsetY = 3;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_ZoneCollide = true;
    }

    // Update is called once per frame
    void Update()
    {
        /// pour empecher la map de defiller lors d'une collision
        RaycastHit2D[] hit = Physics2D.RaycastAll(m_player.transform.position + new Vector3(0,m_raycastOffsetY), Vector2.left);
        m_ZoneCollide = false;
        foreach (RaycastHit2D obstacle in hit)
        {
           
            if (obstacle.collider.tag == "ZoneLimite")
            {
                
                m_distanceRight = Vector2.Distance(new Vector2(obstacle.collider.transform.position.x,0), new Vector2(m_player.transform.position.x,0));
                if (m_distanceRight < 6)
                {
                    
                    m_ZoneCollide = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
        }
        RaycastHit2D[] hit2 = Physics2D.RaycastAll(m_player.transform.position + new Vector3(0, m_raycastOffsetY), Vector2.right);
        foreach (RaycastHit2D obstacle2 in hit2)
        {
            
            if (obstacle2.collider.tag == "ZoneLimite")
            {
               
                m_distanceLeft = Vector2.Distance(new Vector2(obstacle2.collider.transform.position.x, 0), new Vector2(m_player.transform.position.x, 0));
                if (m_distanceLeft < 6)
                {
                    
                    m_ZoneCollide = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
        }



        if (!m_ZoneCollide)
        {
            
                GetComponent<Rigidbody2D>().velocity = new Vector2(m_player.GetComponent<Rigidbody2D>().velocity.x / m_speed, 0);
            
        }
        
    }
}
