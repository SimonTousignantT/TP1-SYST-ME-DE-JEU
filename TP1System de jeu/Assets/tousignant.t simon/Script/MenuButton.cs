using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private GameObject m_soundManager;
    private GameObject m_DataInfo;
    [SerializeField]
    private Audio m_audio;
    // Start is called before the first frame update
    void Start()
    {
        m_DataInfo = GameObject.Find("DataInfo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        
        try
        {
            m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_buttonClic);
            m_DataInfo.GetComponent<DataSave>().LoadFromJson();

        }
        catch 
        {
            Debug.Log("aucune save");
        }
        SceneManager.LoadScene("LvLSelect");

    }
    public void NewGame()
    {
        m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_buttonClic);
        m_DataInfo.GetComponent<DataSave>().ResetData();
        SceneManager.LoadScene("LvLSelect");
        
    }
    public void ExitGame()
    {
        m_soundManager.GetComponent<AudioSource>().PlayOneShot(m_audio.m_buttonClic);
        Application.Quit();
    }
}
