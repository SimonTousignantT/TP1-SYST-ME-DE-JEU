using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarCompletion : MonoBehaviour
{
    [SerializeField]
    private bool m_isLvl1;
    [SerializeField]
    private bool m_isLvl2;
    [SerializeField]
    private bool m_isLvl3;
    [SerializeField]
    private StarColor m_dataColor;
    private GameObject m_dataInfo;
    private float m_topScore;
    [SerializeField]
    private float m_toCompletionBronze = 3;
    [SerializeField]
    private float m_toCompletionSilver = 5;
    [SerializeField]
    private float m_toCompletionGold = 8;
    private Color m_color;
    // Start is called before the first frame update
    void Start()
    {
        m_dataInfo = GameObject.Find("DataInfo");
    }

    // Update is called once per frame
    void Update()
    {
        //// recupere le top score du lvl
        if(m_isLvl1)
        {
            m_topScore = m_dataInfo.GetComponent<DataSave>().GetTopScore(0);
        }
        if (m_isLvl2)
        {
            m_topScore = m_dataInfo.GetComponent<DataSave>().GetTopScore(1);
        }
        if (m_isLvl3)
        {
            m_topScore = m_dataInfo.GetComponent<DataSave>().GetTopScore(2);
        }
        //// verifi quelle couleur choisir et l'atribu a l'etoile 
        
        if(m_toCompletionBronze <= m_topScore)
        {
            m_color = m_dataColor.m_bronze;
        }
        else
        {
            m_color = m_dataColor.m_gray;
        }
        if (m_toCompletionSilver <= m_topScore)
        {
            m_color = m_dataColor.m_silver;
        }
        if (m_toCompletionGold <= m_topScore)
        {
            m_color = m_dataColor.m_gold;
        }
        gameObject.GetComponent<RawImage>().color = m_color; 
    }
}
