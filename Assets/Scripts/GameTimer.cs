using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    float timer = 30.0f;

    [SerializeField]
    GameObject resultButton;

    [SerializeField]
    GameObject currentScore;

    [SerializeField]
    Text ui;

    [SerializeField]
    Text result;



    bool ingame;
    public void StartGame()
    {
        ingame = true;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ingame = false;
            resultButton.SetActive(true);
            currentScore.SetActive(false);
            result.text = GameManager.Instance.Score.ToString();
        }
        else
        {
            ui.text = ((int)timer).ToString();
        }
    }


}
