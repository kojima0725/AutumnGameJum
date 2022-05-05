//  CurveBar.cs
//  http://kan-kikuchi.hatenablog.com/entry/CurveBar
//
//  Created by kan.kikuchi on 2016.01.08.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]

/// <summary>
/// カーブした板
/// </summary>
public class CurveBar : MonoBehaviour
{

    //曲線
    [SerializeField]
    private BezierCurve _bezierCurve;

    //コライダーの太さ
    [SerializeField]
    [Range(0.01f, 10)]
    private float _colliderThickness = 0.1f;

    //コライダーに対する線の太さ
    [SerializeField]
    [Range(0.01f, 10)]
    private float _lineThicknessRate = 1.0f;

    //点を置く間隔
    [SerializeField]
    [Range(0.01f, 10)]
    private float _pointInterval = 0.2f;

    //=================================================================================
    //初期化
    //=================================================================================

    private void Start()
    {
        AdJust();
    }

    private void OnValidate()
    {
        AdJust();
    }

    //レンダラーとコライダーを調整する
    [ContextMenu("AdJust")]
    private void AdJust()
    {

        //線の長さから設定する点の個数を決定
        int pointNum = Mathf.Max(1, (int)(_bezierCurve.length / _pointInterval));

        //点の座標を取得
        List<Vector2> pointList = new List<Vector2>();
        List<Vector2> setPointList = new List<Vector2>();

        for (int i = 0; i <= pointNum; i++)
        {
            Vector2 point = (Vector2)(_bezierCurve.GetPointAt((float)i / (float)pointNum) - transform.position);
            pointList.Add(point);
        }

        //上の線
        for (int i = -1; i <= pointNum; i++)
        {
            setPointList.Add(CalcSetPoint(i, pointList, false));
        }

        //下の線
        for (int i = pointNum; i >= -1; i--)
        {
            setPointList.Add(CalcSetPoint(i, pointList, true));
        }

        //コリジョン設定
        gameObject.GetComponent<PolygonCollider2D>().points = setPointList.ToArray();

        //レンダラー設定
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
        float lineWidth = _colliderThickness * _lineThicknessRate;
        renderer.SetWidth(lineWidth, lineWidth);

        List<Vector3> rendererPoints = new List<Vector3>();

        foreach (Vector2 point in pointList)
        {
            rendererPoints.Add(point);
        }

        renderer.SetVertexCount(rendererPoints.Count);
        renderer.SetPositions(rendererPoints.ToArray());
    }

    //設定地点を計算する
    private Vector2 CalcSetPoint(int i, List<Vector2> pointList, bool isBottomPoint)
    {

        Vector2 point1, point2;

        if (i <= 0)
        {
            point1 = pointList[0];
            point2 = pointList[1];
        }
        else
        {
            point1 = pointList[i - 1];
            point2 = pointList[i];
        }

        //前回の点、今回の点の2点間の角度を求め、
        //さらそこに90度加算することで、
        //2点間にかかる線分に下りる垂線と平行にになる線(前回の点から線を引いて)の角度を求める
        float aim = GetAim(point2, point1);
        float correctionAim = 90;

        if (isBottomPoint)
        {
            correctionAim *= -1;
        }

        if (point1.y < point2.y)
        {
            aim = GetAim(point1, point2);
            correctionAim *= -1;
        }

        aim += correctionAim;

        //前回の点を角度の方向に移動
        Vector2 setPoint = Vector2.zero;
        if (i == -1)
        {
            point2 = point1;
        }

        setPoint.x = (float)(point2.x + _colliderThickness * 0.5f * Mathf.Cos(Mathf.Deg2Rad * aim));
        setPoint.y = (float)(point2.y + _colliderThickness * 0.5f * Mathf.Sin(Mathf.Deg2Rad * aim));

        return setPoint;
    }

    //p2からp1への角度を求める
    private float GetAim(Vector2 p1, Vector2 p2)
    {
        Vector2 a = new Vector2(1, 0);
        Vector2 b = p2 - p1;
        return Vector2.Angle(a, b);
    }

}