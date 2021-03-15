using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Vector3[] patrolPoints;
    public int currentPatrolPoint = 1;
    public float patrolSpeed = 5.0f;

    private void Start()
    {
        transform.position = patrolPoints[0];
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, patrolPoints[currentPatrolPoint], patrolSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, patrolPoints[currentPatrolPoint]) < 0.5f)
        {
            currentPatrolPoint++;
            if (currentPatrolPoint >= patrolPoints.Length)
                currentPatrolPoint = 0;
        }
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < patrolPoints.Length; i++)
        {
            if (i == patrolPoints.Length - 1)
                break;
            Gizmos.DrawLine(patrolPoints[i], patrolPoints[i + 1]);
        }
    }
}
