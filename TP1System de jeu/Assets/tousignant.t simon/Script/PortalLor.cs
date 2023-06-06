using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLor : MonoBehaviour
{
    private GameObject m_portal;
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private GameObject m_canvas;
    [SerializeField]
    private float m_distanceShow = 10;
    // Start is called before the first frame update
    void Start()
    {
        m_portal = this.gameObject;
        m_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Vector2.Distance(m_player.transform.position,m_portal.transform.position) < m_distanceShow)
        {
            m_canvas.SetActive(true);
        }
        else
        {
            m_canvas.SetActive(false);
        }
    }
}
