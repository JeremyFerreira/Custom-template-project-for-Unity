using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTest : MonoBehaviour
{
    [SerializeField] Transform p0;
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;
    [SerializeField] Transform p3;
    private void OnDrawGizmos()
    {
        GizmoExtension.DrawCubicBezierCurve(transform.position, p0.position, p1.position, p2.position,p3.position, 100);
    }
}
