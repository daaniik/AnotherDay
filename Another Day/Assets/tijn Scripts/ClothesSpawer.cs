using UnityEngine;

public class ClothesSpawner : MonoBehaviour
{
    public GameObject[] shirtsPrefabs;
    public GameObject[] pantsPrefabs;
    public Transform[] shirtSpawnPoints;    
    public Transform[] pantsSpawnPoints;    

    void Start()
    {
        SpawnShirts();
        SpawnPants();
    }

    void SpawnShirts()
    {
        Shuffle(shirtSpawnPoints);
        for (int i = 0; i < 3; i++)
            Instantiate(shirtsPrefabs[Random.Range(0, shirtsPrefabs.Length)], shirtSpawnPoints[i].position, shirtSpawnPoints[i].rotation);
    }

    void SpawnPants()
    {
        Shuffle(pantsSpawnPoints);
        for (int i = 0; i < 2; i++)
            Instantiate(pantsPrefabs[Random.Range(0, pantsPrefabs.Length)], pantsSpawnPoints[i].position, pantsSpawnPoints[i].rotation);
    }

    void Shuffle(Transform[] points)
    {
        for (int i = points.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (points[i], points[j]) = (points[j], points[i]);
        }
    }
}