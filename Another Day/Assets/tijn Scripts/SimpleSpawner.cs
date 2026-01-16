using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject[] clothesPrefabs;
    public Transform[] spawnPoints;
    public int maxSpawn = 4;

    void Start()
    {
        int count = Mathf.Min(maxSpawn, clothesPrefabs.Length, spawnPoints.Length);
        for (int i = 0; i < count; i++)
        {
            Instantiate(clothesPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }
}