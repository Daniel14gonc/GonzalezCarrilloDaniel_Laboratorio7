using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayInfo;
        Vector3 pos = Input.mousePosition;
        Ray myRay = Camera.main.ScreenPointToRay(pos);
        if(Physics.Raycast(myRay, out rayInfo) && Input.GetMouseButton(0))
        {
            NavMeshHit nmHit;
            if(NavMesh.SamplePosition(rayInfo.point, out nmHit, 2, NavMesh.AllAreas))
                agent.SetDestination(nmHit.position);
        }
        animator.SetFloat("Velocity", Mathf.Abs(agent.velocity.x));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
