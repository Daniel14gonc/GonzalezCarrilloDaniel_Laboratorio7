using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villain : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject wayPointsObject;
    Animator animator;
    List<Vector3> wayPoints;
    int currentWayPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        wayPoints = new List<Vector3>();
        if (wayPointsObject)
        {
            foreach (Transform child in wayPointsObject.transform)
            {
                wayPoints.Add(child.position);
            }
        }

        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(agent.velocity.x));
        int position = Random.Range(0, wayPoints.Count);
        if (agent)
        {
            if (agent.remainingDistance < 0.5f)
            {
                int newWP = currentWayPoint;
                while (newWP == currentWayPoint)
                    newWP = Random.Range(0, wayPoints.Count);

                currentWayPoint = newWP;
                agent.SetDestination(wayPoints[currentWayPoint]);
            }
        }
    }
}
