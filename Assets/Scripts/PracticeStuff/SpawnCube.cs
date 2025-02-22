using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefabToInstantiate;

    [SerializeField] private bool isActive = true;
    [SerializeField] private int m_amountOfCubes = 10;
    [SerializeField] private float m_cubeLength = 1;
    [SerializeField] private float m_gapWidth = 1;
    [SerializeField] private float rotateDegree = 45;
    [SerializeField] private float delay = 0.05f;
    [SerializeField] private int maxAmount = 100;
    private int coroutineCount = 0;
    private List<GameObject> cubeList = new();
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpinAndSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Spawn New Cubes")]
    private void SpawnNewCube()
    {
        for (int i = 0; i < m_amountOfCubes; i++)
        {
            float spawnPosX = i * (m_cubeLength + m_gapWidth);
            Vector3 spawnPos = new Vector3(spawnPosX, 0, 0);

            Vector3 worldPos = transform.TransformPoint(spawnPos);
            GameObject instantiatedObj = Instantiate(cubePrefabToInstantiate, worldPos, transform.rotation);
            cubeList.Add(instantiatedObj);
        }

    }

    [ContextMenu("Destroy All Spawned Cubes")]
    private void DestroyAllSpawnedCubes()
    {
        foreach (GameObject cube in cubeList)
        {
            Destroy(cube);
        }

        cubeList.Clear();
    }

    IEnumerator SpinAndSpawnRoutine()
    {
        if (!isActive || coroutineCount > maxAmount)
        {
            yield break;
        }
        
        yield return null;
        for (int i = 0; i < 8; i++)
        {
            SpawnNewCube();
            transform.Rotate(0, rotateDegree, 0);
            transform.position += Vector3.up;
            yield return new WaitForSeconds(delay);
        }
        coroutineCount++;
        StartCoroutine(SpinAndSpawnRoutine());
    }
}
