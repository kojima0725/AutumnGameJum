using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    int _score;
    public int Score => _score;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameStart()
    {
        _score = 0;
    }
    public void GetItem(int score)
    {
        _score += score;
    }
}
