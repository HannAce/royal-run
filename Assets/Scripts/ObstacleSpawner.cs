using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float obstacleSpawnInterval;
    private int objectsSpawned = 0; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(nameof(SpawnObstacles));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
            objectsSpawned++;
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }
}
