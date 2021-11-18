using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFuritManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_furits;
    /// <summary>開始地点</summary>
    [SerializeField] GameObject m_firstField;
    /// <summary>終了地点</summary>
    [SerializeField] GameObject m_secondField;
    /// <summary>終了地点</summary>
    [SerializeField] float m_interval;

    float m_time;

    void Update()
    {
        Generate();
    }

    void Generate()
    {
        m_time += Time.deltaTime;
        if(m_time > m_interval)
        {
            GameObject fruit = m_furits[Random.Range(0, m_furits.Length)];
            Vector3 randomPosition = new Vector3(Random.Range(m_firstField.transform.position.x, m_secondField.transform.position.y), Random.Range(m_firstField.transform.position.y,m_secondField.transform.position.y),0);
            Instantiate(fruit,randomPosition,Quaternion.identity);
            m_time = 0;
        }
    }
}
