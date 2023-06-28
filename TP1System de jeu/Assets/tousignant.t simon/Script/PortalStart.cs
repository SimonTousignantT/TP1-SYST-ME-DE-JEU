using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalStart : MonoBehaviour
{
    [SerializeField]
    private int m_WhatIsLvl;
    private GameObject m_soundManager;
    [SerializeField]
    private Audio m_audio;
    // Start is called before the first frame update
    void Start()
    {
        m_soundManager = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadLvl()
    {
        m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_buttonClic);
        m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_portal);
        SceneManager.LoadScene(m_WhatIsLvl);
    }

}
