using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public DataInfo m_dataInfo = new DataInfo();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < m_dataInfo.m_dataScore.Length; i++)
        {
            if (m_dataInfo.m_dataScore[i] > m_dataInfo.m_dataTopScore[i])
            {
                m_dataInfo.m_dataTopScore[i] = m_dataInfo.m_dataScore[i];
            }
        }

    }
    public void SaveToJson()
    {
        string data = JsonUtility.ToJson(m_dataInfo);
        string filePath = Application.persistentDataPath + "data.json";
        System.IO.File.WriteAllText(filePath, data);
    }
    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "data.json";
        string data = System.IO.File.ReadAllText(filePath);
        m_dataInfo = JsonUtility.FromJson<DataInfo>(data);
    }
    public void ResetData()
    {
        for (int i = 0; i < m_dataInfo.m_dataTopScore.Length; i++)
        {
            m_dataInfo.m_dataTopScore[i] = 0;
            m_dataInfo.m_dataScore[i] = 0;
        }
        SaveToJson();
    }
    public float GetScore(int lvl)
    {
        return (m_dataInfo.m_dataScore[lvl]);
    }
    public void SetScore(int lvl, float score)
    {
        m_dataInfo.m_dataScore[lvl] = score;
    }
    public int GetLastLvl()
    {
        return (m_dataInfo.m_dataLastLvl);
    }
    public void SetLvlMenuScore(int lvl)
    {
        m_dataInfo.m_dataLastLvl = lvl;
    }
    public float GetTopScore(int lvl)
    {
        return (m_dataInfo.m_dataTopScore[lvl]);
    }
}
[System.Serializable]
public class DataInfo 
{
    public float[] m_dataScore;
    public float[] m_dataTopScore;
    public int m_dataLastLvl;
}