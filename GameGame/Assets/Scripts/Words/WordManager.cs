using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] List<Word> WordList; 
    [SerializeField] List<Word> RemovedWordsList;
    [SerializeField] GameObject WordPrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] float SpawnTime = 3;
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
        // Timer for generating new words during gameplay
        do
        {
            yield return new WaitForSeconds(SpawnTime);
            SpawnWord();

        } while (CanSpawnWord);
    }

    public void SpawnWord()
    {

        if (WordList.Count == 0)
        {
            print("out of words, cannot spawn new ones");
            return;
        }

        print("Spawning word");
        // use word prefab to spawn in word and attach a word SO to it from word list
        GameObject newWordGO = Instantiate(WordPrefab, canvas.transform, true);
        
        Vector3 position = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), 0);
        newWordGO.transform.localPosition = position;

        int randomWordIndex = Random.Range(0, WordList.Count);

        Word newWord = WordList[randomWordIndex];
        RemoveWord(randomWordIndex);

        KCListener NewWordListener = newWordGO.GetComponentInChildren<KCListener>();
        NewWordListener.wordManager = this;
        print($"giving word {newWord}");
        NewWordListener.SetWord(newWord);

    }

    public void AddWord(Word newWord)
    {
        WordList.Add(newWord);
    }

    public void RemoveWord(int index)
    {
        WordList.RemoveAt(index);
    }

    public void RemoveWord(Word word)
    {
        if (WordList.Contains(word))
        {
            WordList.Remove(word);
        }
        else
        {
            Debug.LogWarning($"tried to remove word {word.text} not in word list");
        }
    }
}
