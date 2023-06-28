using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasScore : MonoBehaviour
{
    [SerializeField]
    private Text m_text;
    private string m_description = "Ramasser 6 coin et finir le niveau pour avoir le score maximal  ... nombre de coin ramasser : ";
    private string m_description2 = "/6";
    private float m_nbCoin = 0;
    private GameObject m_player;
    [SerializeField]
    private bool m_isBossLvl = false;
    // Start is called before the first frame update
    void Start()
    {
        if(m_isBossLvl)
        {
            m_description = "fraper le Boss 6 fois pour le tuer : ";
        }
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        m_nbCoin = m_player.GetComponent<PlayerMove>().ShareScore();
        m_text.text = m_description + m_nbCoin + m_description2;
    }
}
