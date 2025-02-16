using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject m_chunkPrefab;
    [SerializeField] private Transform m_chunkContainer;
    
    [SerializeField] private int m_startingChunkAmount;
    [SerializeField] private float m_chunkLength;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < m_startingChunkAmount; i++)
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

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPosZ);

            Instantiate(m_chunkPrefab, chunkSpawnPos, Quaternion.identity, m_chunkContainer);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
