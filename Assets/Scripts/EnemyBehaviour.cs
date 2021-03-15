using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Vector3[] patrolPoints;
    public int currentPatrolPoint = 1;
    public float patrolSpeed = 5.0f;
    public NavMeshAgent enemyAgent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangePatrolPoint());
        transform.position = patrolPoints[0];
    }

    private IEnumerator ChangePatrolPoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.2f, 1.8f));
            currentPatrolPoint = Random.Range(0, patrolPoints.Length);
            enemyAgent.SetDestination(patrolPoints[currentPatrolPoint]);
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            if (i == patrolPoints.Length - 1)
                break;
            Gizmos.DrawLine(patrolPoints[i], patrolPoints[i + 1]);
        }
    }
}
