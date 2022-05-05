using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineFactoryTest : MonoBehaviour
{
    //private LineRenderer lineRenderer;
    //private int index;
    //private Camera mainCamera;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //    index = 0;
    //    mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //ボタンを押した時最初の点を決める。
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // これでどうでしょうか?
    //        var pos = Input.mousePosition;
    //        pos.z = 10;
    //        pos = mainCamera.ScreenToWorldPoint(pos);


    //        index++;
    //        lineRenderer.positionCount = index;
    //        lineRenderer.SetPosition(index - 1, pos);
    //    }
    //    //ボタンを押している間線を引く。
    //    if (Input.GetMouseButton(0))
    //    {

    //        var posSecond = Input.mousePosition;
    //        posSecond.z = 10.0f;
    //        posSecond = mainCamera.ScreenToWorldPoint(posSecond);

    //        index++;
    //        lineRenderer.positionCount = index;
    //        lineRenderer.SetPosition(index - 1, posSecond);
    //    }
    //    if (!(Input.GetMouseButton(0)))
    //    {
    //        index = 0;
    //    }
    //}
}
