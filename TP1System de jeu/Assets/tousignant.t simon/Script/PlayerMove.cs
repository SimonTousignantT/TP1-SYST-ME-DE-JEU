using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    private float m_velocityY;
    private float m_velocityX;
    [SerializeField]
    private float m_playerSpeed = 10;
    [SerializeField]
    private float m_jumpForce = 4;
    private bool m_firstJump = true;
    [SerializeField]
    private float m_gravity = 7;
    private bool m_isDead = false;
    private Vector2 m_diePos;
    private Vector3 m_rotationOnDeath;
    private float m_detectionOffsetY = 3;
    [SerializeField]
    private float m_playerAtkRange = 1;
    [SerializeField]
    private GameObject m_reward;
    [SerializeField]
    private float m_spawnRewardOffsetY = 3;
    private int m_score = 0;
    private float m_DieChronos = 0;
    private float m_DieTimer = 2;
    [SerializeField]
    private int m_WathIsThisLvl;
    private GameObject m_DataInfo;
    private GameObject m_soundManager;
    [SerializeField]
    private Audio m_audio;
    // Start is called before the first frame update
    void Start()
    {
        m_DataInfo = GameObject.Find("DataInfo");
        m_WathIsThisLvl -= 1;
        m_soundManager = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        ///gere le respawn
        if (m_isDead)
        {
            m_DieChronos += Time.deltaTime;
            if (m_DieChronos > m_DieTimer)
            {
                m_DieChronos = 0;
                SceneManager.LoadScene("GameOver");
            }
        }
        ///gere les deplacement
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(m_playerSpeed * -1, m_velocityY);
            transform.localScale = new Vector2(-1, 1);
            GetComponent<Animator>().SetBool("walk", true);
        }
        m_velocityX = GetComponent<Rigidbody2D>().velocity.x;
        if (m_firstJump)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<Animator>().SetBool("jump", true);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = m_gravity;
                GetComponent<Rigidbody2D>().velocity = new Vector2(m_velocityX, m_jumpForce);
                m_firstJump = false;
            }
        }
        if (m_isDead)
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = m_diePos;
            transform.localScale = m_rotationOnDeath;
        }
        ////////// gere le combat
        if (!m_isDead)
        {
            GetComponent<Animator>().SetBool("atk", false);
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position + new Vector3(0, m_detectionOffsetY), new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0), m_playerAtkRange);
            foreach (RaycastHit2D obstacle in hit)
            {
                if (obstacle.collider.tag == "Enemie")
                {
                    Instantiate(m_reward).transform.position = obstacle.collider.gameObject.transform.position + new Vector3(0, m_spawnRewardOffsetY);
                    GetComponent<Animator>().SetBool("atk", true);
                    obstacle.collider.gameObject.GetComponent<EnemieAI>().enabled = false;
                    obstacle.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    obstacle.collider.gameObject.GetComponent<Animator>().SetTrigger("isDead");
                    obstacle.collider.gameObject.tag = "Untagged";
                    m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_death);
                }
                if (obstacle.collider.tag == "Boss")
                {
                    Instantiate(m_reward).transform.position = obstacle.collider.gameObject.transform.position + new Vector3(0, m_spawnRewardOffsetY);
                    GetComponent<Animator>().SetBool("atk", true);
                    obstacle.collider.gameObject.GetComponent<EnemieAI>().enabled = false;
                    obstacle.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    obstacle.collider.gameObject.GetComponent<Animator>().SetBool("BossDie", true);
                    obstacle.collider.gameObject.GetComponent<BossAfterHit>().enabled = true;
                    obstacle.collider.gameObject.tag = "Untagged";
                    m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_death);
                }
            }
        }
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.tag == "Reward")
        {
            Destroy(collision.gameObject);
            m_score += 1;
        }
        else
        {
            m_firstJump = true;
            GetComponent<Animator>().SetBool("jump", false);
        }
    }
    public void TakeDamage(float dropSpeed)
    {
        m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_death);
        m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_deathHero);
        GetComponent<Animator>().SetTrigger("isDead");
        m_diePos = new Vector2(0,dropSpeed);
        m_rotationOnDeath = transform.localScale;
        m_isDead = true;
        gameObject.tag = "Untagged";
        ///sauvegarde le score
        ShareScore();
        m_DataInfo.GetComponent<DataSave>().SetScore(m_WathIsThisLvl, m_score);
        m_DataInfo.GetComponent<DataSave>().SetLvlMenuScore(m_WathIsThisLvl);
        m_DataInfo.GetComponent<DataSave>().SaveToJson();
        
    }
    public float ShareScore()
    {
        return (m_score);
    }
}
