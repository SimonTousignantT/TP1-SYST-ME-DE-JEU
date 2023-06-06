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
    // Start is called before the first frame update
    void Start()
    {
        
        if (m_isLvl1)
        {
            m_myText[0] = "Baal a great ninja lord full of ambition is setting the land in fire and blood, It's time to intervene! ";
            m_myText[1] = "the plan?";
            m_myText[2] = "What plan?";
            m_myText[3] = "no really just strength in the heap!";
        }
        if (m_isLvl2)
        {
            m_myText[0] = "Now that the enemies are retreating, chase them to discover their hiding place";
            m_myText[1] = "the plan?";
            m_myText[2] = "What plan?";
            m_myText[3] = "no really just strength in the heap!";
        }
        if (m_isLvl3)
        {
            m_myText[0] = "Your enemies have led you straight to Lord Baal's hideout. Go settle his account and bring peace!";
            m_myText[1] = "the plan?";
            m_myText[2] = "What plan?";
            m_myText[3] = "no really just strength in the heap!";
        }
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
