using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject[] m_obstaclePrefabs;
    [SerializeField] private float m_obstacleSpawnInterval;
    [SerializeField] private Transform m_obstacleParent;
    [SerializeField] private float m_spawnWidth;
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
            GameObject obstaclePrefab = m_obstaclePrefabs[Random.Range(0, m_obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-m_spawnWidth, m_spawnWidth), transform.position.y, transform.position.z);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, m_obstacleParent);
            objectsSpawned++;
            yield return new WaitForSeconds(m_obstacleSpawnInterval);
        }
    }
}
