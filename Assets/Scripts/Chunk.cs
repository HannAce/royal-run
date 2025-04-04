using System;
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
        int randomLaneIndex = Random.Range(0, lanes.Length);
        Vector3 spawnPosition = new Vector3(lanes[randomLaneIndex], transform.position.y, transform.position.z);
        Instantiate(m_fencePrefab, spawnPosition, Quaternion.identity, transform);
    }
}
