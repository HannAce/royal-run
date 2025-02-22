using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject m_chunkPrefab;
    [SerializeField] private Transform m_chunkContainer;
    
    [SerializeField] private int m_startingChunkAmount;
    [SerializeField] private float m_chunkLength;
    [SerializeField] private float m_moveSpeed;
    
    private GameObject[] m_chunks = new GameObject[12];
    
    void Start()
    {
        SpawnChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < m_startingChunkAmount; i++)
        {
            float spawnPosZ = CalculateSpawnPosZ(i);

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPosZ);

            GameObject newChunk = Instantiate(m_chunkPrefab, chunkSpawnPos, Quaternion.identity, m_chunkContainer);
            
            m_chunks[i] = newChunk;
        }
    }

    private float CalculateSpawnPosZ(int i)
    {
        float spawnPosZ;

        if (i == 0)
        {
            spawnPosZ = transform.position.z;
        }
        else
        {
            spawnPosZ = transform.position.z + (i * m_chunkLength);
        }

        return spawnPosZ;
    }

    private void MoveChunks()
    {
        for (int i = 0; i < m_chunks.Length; i++)
        {
            m_chunks[i].transform.Translate(0, 0, -1 * m_moveSpeed * Time.deltaTime);
        }
    }
}
