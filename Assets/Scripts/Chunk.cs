using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject m_fencePrefab;
    [SerializeField] private float[] lanes = { -2.5f, 0, 2.5f };

    private void Start()
    {
        SpawnFence();
    }

    private void SpawnFence()
    {
        List<int> availableLanes = new List<int> { 0, 1, 2 };
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0)
            {
                break;
            }
            
            int randomLaneIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);
            
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(m_fencePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
