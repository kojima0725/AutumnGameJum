using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public int m_point;
    [SerializeField] string m_ground;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == m_ground)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == m_ground)
        {
            Destroy(this.gameObject);
        }
    }
}
