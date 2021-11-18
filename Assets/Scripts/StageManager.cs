using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.GameStart();
    }
}
