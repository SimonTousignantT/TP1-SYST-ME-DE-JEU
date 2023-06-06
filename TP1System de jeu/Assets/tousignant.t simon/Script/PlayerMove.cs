using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMove : MonoBehaviour
{
    private float m_velocityY;
    [SerializeField]
    private float m_playerSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool("walk", false);
        m_velocityY = GetComponent<Rigidbody2D>().velocity.y;
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(m_playerSpeed, m_velocityY);
            transform.localScale = new Vector2(1, 1);
            GetComponent<Animator>().SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(m_playerSpeed  * -1, m_velocityY);
            transform.localScale = new Vector2(-1, 1);
            GetComponent<Animator>().SetBool("walk", true);
        }
    }
}
