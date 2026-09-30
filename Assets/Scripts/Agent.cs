using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class Agent : MonoBehaviour
{
    public GameObject target;

    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(navMeshAgent);

        target.transform.parent = null;
    }

    public void SetDestination(Vector3 dest)
    {
        navMeshAgent.SetDestination(dest);
    }

    void Update()
    {
        ScoreboardController
            .GetInstance()
            .SetScore(Mathf.FloorToInt(navMeshAgent.remainingDistance));

        if (navMeshAgent.remainingDistance < .1f)
        {
            Vector3 newDest = transform.position + Random.onUnitSphere * 20f;

            SetDestination(newDest);
        }

        target.transform.position = navMeshAgent.destination;
    }
}
