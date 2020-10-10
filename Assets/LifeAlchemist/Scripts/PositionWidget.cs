using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWidget : MonoBehaviour
{
    public float widgetRadius = 1.0f;
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, widgetRadius);
    }
}
