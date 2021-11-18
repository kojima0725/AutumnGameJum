using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    Text _text;

    private void Update()
    {
        _text.text = $"スコア:{GameManager.Instance.Score}";
    }
}
