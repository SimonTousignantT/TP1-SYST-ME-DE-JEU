using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LorText : MonoBehaviour
{
    [SerializeField]
    private bool m_isLvl1;
    [SerializeField]
    private bool m_isLvl2;
    [SerializeField]
    private bool m_isLvl3;
    private string[] m_myText =  { " "," "," "," " } ;
    [SerializeField]
    private float m_speedScript = 0.05f;
    private int m_index = 0;
    [SerializeField]
    private TextLorObject m_dataText;
    private GameObject m_soundManager;
    [SerializeField]
    private Audio m_audio;
    // Start is called before the first frame update
    private void Awake()
    {

        m_soundManager = GameObject.Find("SoundManager");
        m_myText = m_dataText.m_textLvl;
        
    }
    void Start()
    {
      

    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnEnable()
    {

        StartCoroutine("PlayText");
        
    }
    private void OnDisable()
    {
        GetComponent<Text>().text = "";
        m_index = 0;
    }
    IEnumerator PlayText()
    {
            foreach (char c in m_myText[m_index])
            {
                GetComponent<Text>().text += c;
                yield return new WaitForSeconds(m_speedScript);
            }
       
    }
    public void ButtonNext()
    {
        m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_pageTurnSingle);
        GetComponent<Text>().text = "";
        try 
        {

            m_index += 1;
            m_myText[m_index] = m_myText[m_index];
            GetComponent<Text>().text = "";

        } catch { m_index -= 1; }
        

        StopCoroutine("PlayText");
        StartCoroutine("PlayText");
    }
}
