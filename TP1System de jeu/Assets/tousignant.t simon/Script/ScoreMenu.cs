using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField]
    private Text m_textScore;
    [SerializeField]
    private Text m_textTopScore;
    private float m_score = 0;
    private float m_topScore = 0;
    private int m_lvl;
    [SerializeField]
    private string m_scoreTxt = "your score : ";
    [SerializeField]
    private string m_topScoreTxt = "your top score : ";
    private GameObject m_scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        m_scoreManager = GameObject.Find("DataInfo");
        m_lvl = m_scoreManager.GetComponent<DataSave>().GetLastLvl();
        m_score = m_scoreManager.GetComponent<DataSave>().GetScore(m_lvl);
        m_topScore = m_scoreManager.GetComponent<DataSave>().GetTopScore(m_lvl);
        m_textScore.text = m_scoreTxt + m_score;
        m_textTopScore.text = m_topScoreTxt + m_topScore;
    }
}
