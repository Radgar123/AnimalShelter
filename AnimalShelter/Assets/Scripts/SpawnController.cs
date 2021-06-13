using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("Spawn Agents Manager")]

    [Range(2, 10)]
    [SerializeField] private int timeToSpawn = 2;
    [SerializeField] private int maxNumbersOfAgents = 30;
    public static int actualNumberOfAgents;
    public List<Transform> agentSpawnPoints;
    public GameObject AgentPrefab;

    [Header("Spawn Point To Follow")]

    public List<Transform> followingPoints;
    public GameObject followPrefab;
    public GameObject followPrefabTemp = null;

    private void Start()
    {
        StartCoroutine(SpawnAgentsInSeconds());
        StartCoroutine(SpawnFollowingPointInSeconds());
    }

    public void SpawnAgentsInPoints()
    {
        if (actualNumberOfAgents <= maxNumbersOfAgents)
        {
            int spawnPointID = Random.Range(0, agentSpawnPoints.Count);
            Instantiate(AgentPrefab, agentSpawnPoints[spawnPointID].position, agentSpawnPoints[spawnPointID].rotation);
            actualNumberOfAgents++;
        }
    }

    public void SpawnFollowingPointInPoints()
    {
        if (followPrefabTemp != null)
        {
            Destroy(followPrefabTemp);
            int followPointID = Random.Range(0, followingPoints.Count);
            Instantiate(followPrefab, followingPoints[followPointID].position, followingPoints[followPointID].rotation);
        }
        else
        {
            int followPointID = Random.Range(0, followingPoints.Count);
            Instantiate(followPrefab, followingPoints[followPointID].position, followingPoints[followPointID].rotation);
            followPrefabTemp = GameObject.FindWithTag("Follow");
        }
    }

    IEnumerator SpawnAgentsInSeconds()
    {
        SpawnAgentsInPoints();
        yield return new WaitForSeconds(timeToSpawn);
        StartCoroutine(SpawnAgentsInSeconds());
    }

    IEnumerator SpawnFollowingPointInSeconds()
    {
        int waitTime = Random.Range(2, 5);
        SpawnFollowingPointInPoints();
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnFollowingPointInSeconds());
    }
}
