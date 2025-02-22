using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject m_chunkPrefab;
    [SerializeField] private Transform m_chunkContainer;
    
    [SerializeField] private int m_startingChunkAmount;
    [SerializeField] private float m_chunkLength;
    [SerializeField] private float m_moveSpeed;
    
    private List<GameObject> m_chunks = new();

    private void Awake()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main is null");
        }
    }

    private void Start()
    {
        SpawnStartingChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    // Spawns the first chunks/parts of the floor
    private void SpawnStartingChunks()
    {
        for (int i = 0; i < m_startingChunkAmount; i++)
        {
            SpawnChunk();
        }
    }

    // Spawns a singular chunk/section of floor each time it's called, at the calculated spawn position
    private void SpawnChunk()
    {
        float spawnPosZ = CalculateSpawnPosZ();

        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, spawnPosZ);
        GameObject instantiatedChunk = Instantiate(m_chunkPrefab, spawnPos, Quaternion.identity, m_chunkContainer);
            
        m_chunks.Add(instantiatedChunk);
    }

    // Calculate the position to spawn a chunk/section of floor
    private float CalculateSpawnPosZ()
    {
        float spawnPosZ;

        // If there are no chunks, then spawn the first chunk at the start/under the player
        if (m_chunks.Count == 0)
        {
            spawnPosZ = transform.position.z;
        }
        // If there are other chunks, then spawn the next chunk at the end of the list
        else
        {
            spawnPosZ = m_chunks[m_chunks.Count - 1].transform.position.z + m_chunkLength;
        }

        return spawnPosZ;
    }

    // Move the chunks along towards the player to simulate them running forwards
    private void MoveChunks()
    {
        for (int i = 0; i < m_chunks.Count; i++)
        {
            GameObject chunk = m_chunks[i];
            chunk.transform.Translate(0, 0, -1 * m_moveSpeed * Time.deltaTime);

            // Destroy a chunk once out of view and spawn a new chunk to avoid running out of floor
            if (chunk.transform.position.z <= Camera.main.transform.position.z - m_chunkLength)
            {
                m_chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
