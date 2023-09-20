using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    public Transform homePoint;
    public float distanceMax;

    LineRenderer rend;

    private void Start()
    {
        rend = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, homePoint.position) > distanceMax)
        {
            transform.position = (transform.position - homePoint.position).normalized * distanceMax;
        }

        int segments = Mathf.CeilToInt(Vector3.Distance(transform.position, homePoint.position) / 0.1f);
        rend.positionCount = segments + 1;

        Vector3 previous = homePoint.position;
        rend.SetPosition(0, homePoint.position);
        for (int i = 1; i < segments; i++)
        {
            rend.SetPosition(i, previous + (transform.position - homePoint.position).normalized * 0.1f);
            previous = rend.GetPosition(i);
        }
        rend.SetPosition(segments, transform.position);
    }
}
