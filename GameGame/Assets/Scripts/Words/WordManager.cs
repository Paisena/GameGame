using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] List<Word> WordList;  
    [SerializeField] GameObject WordPrefab;
    public bool CanSpawnWord = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnWordTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWordTimer()
    {
        do
        {
            SpawnWord();
            yield return new WaitForSeconds(5);

        } while (CanSpawnWord);
    }

    public void SpawnWord()
    {
        print("Spawning word");
    }
}
