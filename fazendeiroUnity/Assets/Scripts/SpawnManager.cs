using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject estrelaprefab;
    private float spawnRangeX = 20f;
    private float spawnPositionZ = 20f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    public Placar placar;
    private int lastStarScore = 0;

    void Start()
    {
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
    }
    void SpawnAnimal()
    {
        // escolhe um animal aleatoriamente
        // animalPrefabs.Length retorna o tamanho do vetor
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // escolhe um posição x aleatoriamente
        Vector3 randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
        Instantiate(animalPrefabs[animalIndex], randomPosition, animalPrefabs[animalIndex].transform.rotation);

        if (placar.pontos > lastStarScore && placar.pontos % 200 == 0)
        {
            Instantiate(estrelaprefab, randomPosition, estrelaprefab.transform.rotation);
            lastStarScore = placar.pontos;
            Debug.Log("spanwnado");
        }
    }
}
