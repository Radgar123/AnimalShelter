using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentsController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Renderer rend;
    private AddParametersToAgentInspector addp;
    private int maxStartLife = 3;
    private int actualAgentLife;
    private string agentName;

    private List<GameObject> pointsToFollow;
    private int point;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
        addp = GameObject.FindWithTag("AgentInspector").transform.gameObject.GetComponent<AddParametersToAgentInspector>();
        actualAgentLife = maxStartLife;
        agentName = "Agent" + (int)Random.Range(0,1000);
        ChangeAgentColor();
        StartCoroutine(WaitForRandomAgentMovement());
    }

    private void Update()
    {
        //AgentMovement();
        DestroyAgent();
    }

    private void ChangeAgentColor()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        rend.material.color = newColor;
    }

    public void getHit(int damage)
    {
        actualAgentLife -= damage;
    }

    private void AgentMovement()
    {
        //GameObject point = GameObject.FindGameObjectWithTag("Follow");

        pointsToFollow = new List<GameObject>(GameObject.FindGameObjectsWithTag("Follow"));

        int point = Random.Range(0, pointsToFollow.Count);

        agent.destination = pointsToFollow[point].transform.position;
    }

    IEnumerator WaitForRandomAgentMovement() 
    {
        AgentMovement();
        yield return new WaitForSeconds(5);
        StartCoroutine(WaitForRandomAgentMovement());
    }

    private void DestroyAgent()
    {
        if (this.actualAgentLife <= 0)
        {
            if (addp.GetAgentName() == agentName)
                addp.ResetParametersWhenDestroyAgent();

            SpawnController.actualNumberOfAgents--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Agent")
            actualAgentLife--;
    }

    public int GetActualAgentLife() { return actualAgentLife; }
    public string GetName() { return agentName; }

    public Renderer GetRend() { return rend; }
}
