using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Paralax : MonoBehaviour
{
    private GameObject m_player;
    [SerializeField]
    private GameObject m_image;
    private Vector2 m_length;
    private float m_playerPosX;
    private GameObject m_newImage;
    private GameObject m_newImageNeg;
    [SerializeField]
    private float m_offsetY;
    private float m_lenghtX;
    [SerializeField]
    private GameObject m_flag;
    // Start is called before the first frame update
    void Start()
    {

      
        m_player = this.gameObject;
        m_length = m_image.GetComponentInChildren<SpriteRenderer>().bounds.size ;
        m_lenghtX = m_length.x - 5;
        m_newImage = Instantiate(m_image);
        m_newImage.transform.position = new Vector2(m_playerPosX + (m_lenghtX/2), m_offsetY);
        m_newImageNeg = Instantiate(m_image);
        m_newImageNeg.transform.position = new Vector2(m_playerPosX - (m_lenghtX/2), m_offsetY);
    }

    // Update is called once per frame
    void Update()
    {
     
        m_playerPosX = m_player.transform.position.x ;
        /////////////////////////////////////
        ///
        try
        {
            if (m_playerPosX > m_newImage.transform.position.x)
            {
             
                m_newImage = Instantiate(m_image);
                m_newImage.transform.position = new Vector2(m_playerPosX + m_lenghtX, m_offsetY);
            }
        }
        catch
        {
            m_newImage = Instantiate(m_flag);
            m_newImage.transform.position = new Vector2(m_newImageNeg.transform.position.x + m_lenghtX, m_offsetY);
        }


        try
        {
            if (m_playerPosX < m_newImageNeg.transform.position.x)
            {
               
                m_newImageNeg = Instantiate(m_image);
                m_newImageNeg.transform.position = new Vector2(m_playerPosX - m_lenghtX, m_offsetY);
            }
        }
        catch
        {
            m_newImageNeg = Instantiate(m_flag);
            m_newImageNeg.transform.position = new Vector2(m_newImage.transform.position.x - m_lenghtX, m_offsetY);
        }
        


        ///je recupere la distance entre lanciene et la nouvelle paralax qui se modifi acose de la vitesse
     



    }
}
