using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAI : MonoBehaviour
{
    private bool m_IsAlert = false;
    [SerializeField]
    private float m_patrolDistance = 4;
    private Vector3 m_startposition;
    [SerializeField]
    private float m_enemieSpeed = 10;
    [SerializeField]
    private float m_enemieSpeedAlerted = 30;
    private float m_directionVelocity;
    private float m_scaleX;
    private float m_startScaleX;
    private GameObject m_player;
    [SerializeField]
    private float m_detectionRange = 3;
    private float m_chronos = 0;
    [SerializeField]
    private float m_enemieReactionTimer = 2;
    private float m_detectionOffsetY = 3;
    [SerializeField]
    private float m_attackRange = 3;
    [SerializeField]
    private float m_damageDeal = 10;
    [SerializeField]
    private float m_mapScaleX = 778;
    [SerializeField]
    private float m_mapScaleXStart = -21;
    [SerializeField]
    private bool m_isBoss = false;
    [SerializeField]
    private float m_TimerTeleport = 10;
    private float m_chronosTeleport = 0;
    [SerializeField]
    private GameObject m_portalBoss;
    private float m_portalOffsetY = 4;
    [SerializeField]
    private GameObject m_endPortal;
    private float m_bossPosY = -1;
    private GameObject m_soundManager;
    [SerializeField]
    private Audio m_audio;
    // Start is called before the first frame update
    void Start()
    {
        m_startposition = transform.position;
        m_directionVelocity = m_enemieSpeed;
        m_startScaleX = transform.localScale.x;
        m_player = GameObject.Find("Player");
        m_soundManager = GameObject.Find("SoundManager");

    }

    // Update is called once per frame
    void Update()
    {
        if(m_isBoss)
        {
            gameObject.GetComponent<BossAfterHit>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("BossDie", false);
            m_chronosTeleport += Time.deltaTime;
            if(m_chronosTeleport > m_TimerTeleport)
            {
                m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_portal);
                Instantiate(m_portalBoss).transform.position = gameObject.transform.position + new Vector3(0, m_portalOffsetY);
                gameObject.transform.position = new Vector2(Random.Range(m_mapScaleXStart,m_mapScaleX),m_bossPosY);
                m_chronosTeleport = 0;
                Instantiate(m_portalBoss).transform.position = gameObject.transform.position + new Vector3(0, m_portalOffsetY);
            }
        }
        if(transform.position.x < m_mapScaleXStart)
        {
            transform.position = new Vector3(m_mapScaleXStart, transform.position.y, 0);
        }
        if (transform.position.x > m_mapScaleX)
        {
            transform.position = new Vector3(m_mapScaleX , transform.position.y, 0);
        }
        /////////////// se qui triger l'alerte
        if (Vector2.Distance(m_player.transform.position,transform.position)< m_detectionRange )
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position + new Vector3(0,m_detectionOffsetY), new Vector2(m_directionVelocity,0),Mathf.Infinity);
            foreach (RaycastHit2D obstacle in hit)
            {
                if (obstacle.collider.tag == "Player")
                {
                    m_IsAlert = true;
                    m_enemieSpeed = m_enemieSpeedAlerted;
                }
            }
        }
        /////////////////////// mouvement si non alerté
        if (!m_IsAlert)
        {
            
            if (transform.position.x > m_startposition.x + m_patrolDistance)
            {
                m_directionVelocity = m_enemieSpeed * -1;
                
            }
            if (transform.position.x < m_startposition.x - m_patrolDistance)
            {
                m_directionVelocity = m_enemieSpeed;
                
            }
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(m_directionVelocity, 0);
            GetComponent<Animator>().SetBool("walk", true);
        }
        ////////mouvement si est alerté
        if (m_IsAlert)
        {
            /// le timer ser a se que lenemie ne soit pas invincible car toujours face au joueur. se qui mermet de le fraper dans le dos, 
            m_chronos += Time.deltaTime;
            if (m_chronos > m_enemieReactionTimer)
            {
                m_chronos = 0;
                if (m_player.transform.position.x < transform.position.x )
                {
                    m_directionVelocity = m_enemieSpeed * -1;
                }
                else
                {
                    m_directionVelocity = m_enemieSpeed;
                }
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(m_directionVelocity, 0);
            
        }
        /////////////////////// gere vers ou lenemie regarde
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            m_scaleX = m_startScaleX * -1;
        }
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            m_scaleX = m_startScaleX;
        }
        transform.localScale = new Vector2(m_scaleX, transform.localScale.y);
        /////////////////////// system de combat
        GetComponent<Animator>().SetBool("atk", false);
        if (Vector2.Distance(m_player.transform.position, transform.position) < m_attackRange)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position + new Vector3(0, m_detectionOffsetY), new Vector2(m_directionVelocity, 0), Mathf.Infinity);
            foreach (RaycastHit2D obstacle in hit)
            {
                if (obstacle.collider.tag == "Player")
                {
                    m_player.GetComponent<PlayerMove>().TakeDamage(0);
                    GetComponent<Animator>().SetBool("atk", true);
                }
            }
        }
    }
    
}
