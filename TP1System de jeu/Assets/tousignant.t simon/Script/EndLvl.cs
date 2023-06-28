using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLvl : MonoBehaviour
{
    private GameObject m_endTp;
    [SerializeField]
    private float m_score ;
    private GameObject m_player;
    [SerializeField]
    private float m_distanceEnd = 10;
    [SerializeField]
    private int m_WathIsThisLvl;
    private GameObject m_DataInfo;
    // Start is called before the first frame update
    void Start()
    {
        m_endTp = this.gameObject;
        m_WathIsThisLvl -= 1;
        m_DataInfo = GameObject.Find("DataInfo");
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(m_player.transform.position, m_endTp.transform.position) < m_distanceEnd)
        {
            ///sauvegarde le score
            m_score = m_player.GetComponent<PlayerMove>().ShareScore();
            m_score += 3;
            m_DataInfo.GetComponent<DataSave>().SetScore(m_WathIsThisLvl,m_score);
            m_DataInfo.GetComponent<DataSave>().SetLvlMenuScore(m_WathIsThisLvl);
            m_DataInfo.GetComponent<DataSave>().SaveToJson();
            SceneManager.LoadScene("Score");
        }
    }
}
