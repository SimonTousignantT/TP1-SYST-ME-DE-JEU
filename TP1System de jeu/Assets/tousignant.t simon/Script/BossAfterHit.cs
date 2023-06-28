using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossAfterHit : MonoBehaviour
{
    private float m_chronos = 0;
    [SerializeField]
    private float m_timer = 1f;
    [SerializeField]
    private int m_bossMaxLife = 6;
    private int m_bossLife ;
    [SerializeField]
    private GameObject m_endPortal;
    // Start is called before the first frame update
    void Start()
    {
        m_bossLife = m_bossMaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        ///sert a laisser le temp au joueur de partir apres avoir fraper
        m_chronos += Time.deltaTime;
        if (m_chronos > m_timer)
        {
            m_chronos = 0;
            m_bossLife -= 1;
            try
            {
                gameObject.GetComponent<EnemieAI>().enabled = true;
            }
            catch
            {
                //le boss est mort
            }
            gameObject.tag = "Boss";
        }
        ////Gere La vie Du Boss
        if(m_bossLife <= 0)
        {
            Destroy(gameObject.GetComponent<EnemieAI>());
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Animator>().SetTrigger("isDead");
            gameObject.tag = "Untagged";
            m_endPortal.SetActive(true);
        }
    }
}
