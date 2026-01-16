using UnityEngine;

public class ClothesSpawner : MonoBehaviour
{
    public GameObject[] clothesPrefabs;     
    public Transform[] spawnPoints;        

    void Start()
    {
        SpawnRandomClothes();
    }

    void SpawnRandomClothes()
    {
        for (int i = spawnPoints.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Transform temp = spawnPoints[i];
            spawnPoints[i] = spawnPoints[j];
            spawnPoints[j] = temp;
        }

        for (int i = 0; i < 5; i++)
        {
            int randomCloth = Random.Range(0, clothesPrefabs.Length);
            Instantiate(clothesPrefabs[randomCloth], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }
}