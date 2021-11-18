using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFuritManager : MonoBehaviour
{
    /// <summary>フルーツ</summary>
    [SerializeField] GameObject[] m_furits;
    /// <summary>スペシャルフルーツ</summary>
    [SerializeField] GameObject m_specialFruit;
    /// <summary>開始地点</summary>
    [SerializeField] GameObject m_firstField;
    /// <summary>終了地点</summary>
    [SerializeField] GameObject m_secondField;
    /// <summary>インターバル</summary>
    [SerializeField] float m_interval;
    /// <summary>スペシャルフルーツの確立</summary>
    [SerializeField] float m_specialProbability;

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
            float special = Random.Range(0, 101);
            if(special <= m_specialProbability / m_furits.Length + 1)
            {
                fruit = m_specialFruit;
            }
            Vector3 randomPosition = new Vector3(Random.Range(m_firstField.transform.position.x, m_secondField.transform.position.y), Random.Range(m_firstField.transform.position.y,m_secondField.transform.position.y),0);
            Instantiate(fruit,randomPosition,Quaternion.identity);
            m_time = 0;
        }
    }
}
