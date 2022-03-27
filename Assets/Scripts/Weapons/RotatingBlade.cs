using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlade : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private List<Transform> waypoints;

    private int nextIndex = 0;
    private int idChangeValue = 1;

    void Update()
    {
        transform.Rotate(0, 0, -360 * rotateSpeed * Time.deltaTime);
        MovetoNextPoint();
    }

    private void MovetoNextPoint()
    {
        Transform goalPoint = waypoints[nextIndex];
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.1f)
        {
            if (nextIndex == waypoints.Count - 1)
            {
                idChangeValue = -1;
            }
            if (nextIndex == 0)
            {
                idChangeValue = 1;
            }
            nextIndex += idChangeValue;
        }
    }
}
