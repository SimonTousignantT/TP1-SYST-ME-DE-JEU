using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    [SerializeField]
    private float m_timer = 1;
    private float m_chronos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_chronos += Time.deltaTime;
        if(m_chronos > m_timer)
        {
            Destroy(gameObject);
        }
    }
}
