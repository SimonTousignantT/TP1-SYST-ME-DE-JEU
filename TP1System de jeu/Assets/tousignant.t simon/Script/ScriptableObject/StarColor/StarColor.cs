
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataStarColor", menuName = "ScriptableObjects/StarColor", order = 1)]
public class StarColor : ScriptableObject
{
    // Start is called before the first frame update
    public Color m_gray;
    public Color m_bronze;
    public Color m_silver;
    public Color m_gold;

}