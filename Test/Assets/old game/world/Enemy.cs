using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 5f;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }
    private void Update()
    {
        Vector3 walkdirection = target.position - transform.position;
        transform.Translate(walkdirection.normalized * enemySpeed * Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position,target.position)<=0.2f)
        {
            GetNextWaypoint();
        }
    }
    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }



}
