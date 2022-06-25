using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    int curWaypoint = 0;

    [SerializeField] private float speed = 2;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector2.Distance(waypoints[curWaypoint].transform.position, transform.position));
        Debug.Log(curWaypoint);
        if (Vector2.Distance(waypoints[curWaypoint].transform.position, transform.position)<0.001)
        {
            curWaypoint++;
            curWaypoint %= 2;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[curWaypoint].transform.position, Time.deltaTime*speed);
    }
}
