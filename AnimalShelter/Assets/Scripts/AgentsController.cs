using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentsController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Renderer rend;

    //public GameObject point;

    private int maxStartLife = 3;
    public int actualAgentLife;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
        actualAgentLife = maxStartLife;

        ChangeAgentColor();
    }

    private void Update()
    {
        AgentMovement();
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
        GameObject point = GameObject.FindGameObjectWithTag("Follow");
        agent.destination = point.transform.position;
    }

    private void DestroyAgent()
    {
        if (this.actualAgentLife < 0)
        {
            SpawnController.actualNumberOfAgents--;
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Agent")
            actualAgentLife--;
    }
}
