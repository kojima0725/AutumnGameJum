using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
