using System.Collections;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float fov = 120f;
    [SerializeField]
    private float viewDistance = 10f;

    [SerializeField]
    private float wanderRadius;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private float chaseTime = 20f;

    [SerializeField]
    private float lifePoints = 100f;

    [SerializeField]
    private bool playerNoticed;

    private GameObject player;
    private AIState currentState;
    private bool allowWander;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        currentState = AIState.Wander;
        playerNoticed = false;
        allowWander = true;

        wanderRadius = (float)Random.Range(10, 50) / 10f;
        waitTime = (float)Random.Range(25, 60) / 10f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!playerNoticed)
        {
            LookForPlayer();
        }

        CheckCurrentState();
    }

    private void LookForPlayer()
    {
        if (IsPlayerInSight())
        {
            playerNoticed = true;
            currentState = AIState.Chase;
            Debug.Log("Chasing Player!");
            StartCoroutine(ChaseTimer());
            return;
        }

        currentState = AIState.Wander;
    }

    private IEnumerator ChaseTimer()
    {
        yield return new WaitForSeconds(chaseTime);

        playerNoticed = false;
        currentState = AIState.Wander;
    }

    private bool IsPlayerInSight()
    {
        return PlayerInFOV() && PlayerInDistance();
    }

    private bool PlayerInFOV()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));

        return angleToPlayer >= -fov / 2f && angleToPlayer <= fov / 2f;
    }

    private bool PlayerInDistance()
    {
        Vector3 target = player.transform.position;
        Vector3 enemyPosition = transform.position;

        return Vector3.Distance(target, enemyPosition) <= viewDistance;
    }

    private void CheckCurrentState()
    {
        ChangeMovementSpeed();

        switch (currentState)
        {
            case AIState.Wander :
            {
                if (allowWander)
                {
                    StartCoroutine(Wander());
                }
                break;
            }

            case AIState.Chase :
            {
                ChasePlayer();
                break;
            }

            case AIState.Search :
            {
                break;
            }

            case AIState.Attack :
            {
                break;
            }
        }
    }

    private IEnumerator Wander()
    {
        allowWander = false;
  
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);

        yield return new WaitForSeconds(waitTime);
        allowWander = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void ChangeMovementSpeed()
    {
        if (currentState == AIState.Wander && playerNoticed == false)
        {
            agent.acceleration = 2f;
            agent.angularSpeed = 60f;
            agent.speed = 1f;
        }
        else
        {
            agent.acceleration = 8f;
            agent.angularSpeed = 120f;
            agent.speed = 3f;
        }
        
    }
}
