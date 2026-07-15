using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spawns the terrain the player will dodge
public class TerrainSpawner : MonoBehaviour
{

    [SerializeField] bool CanSpawnTerrain = true;
    [SerializeField] GameObject TerrainPrefab;
    [SerializeField] List<Transform> SpawnPositionList;
    [SerializeField] float SpawnTime = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTerrainTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTerrain()
    {
        // Choose position and place terrain
        // Will have to keep track of if placement will make unwinnable situation

        int WhichPosition = Random.Range(0, SpawnPositionList.Count);

        GameObject newTerrain = Instantiate(TerrainPrefab, SpawnPositionList[WhichPosition]);

        
    }

    IEnumerator SpawnTerrainTimer()
    {
        // Timer for generating new words during gameplay
        do
        {
            yield return new WaitForSeconds(SpawnTime);
            SpawnTerrain();

        } while (CanSpawnTerrain);
    }
}
