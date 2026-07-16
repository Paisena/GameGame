using System;
using System.Collections.Generic;
using UnityEngine;

// TL means Typed Letters
// KC means Key Combo

// TODO: Have to refactor code to handle both uppercase inputs and lowercase inputs

public class KCListener : MonoBehaviour
{
    [SerializeField] List<KeyCode> KeysPressed;
    public WordManager wordManager;
    [SerializeField] public Word word;
    [SerializeField] WordText wordText;
    [SerializeField] KeyCode[] AllowedKeys; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectKeyInputs();
    }

    public void SetWord(Word newWord)
    {
        print("setting word");
        word = newWord;
        wordText.SetupText();
    }

    void DetectKeyInputs()
    {
        foreach (KeyCode kcode in AllowedKeys)
        {
            if (Input.GetKeyDown(kcode))
            {
                KeysPressed.Add(kcode);
            }
        }

        ValidateInputs();
    }

    void ValidateInputs()
    {
        // first check if word matches TL

        // convert word.text to keycode equivalent

        string KeycodeWordEqual = "";


        if (word.text == GetKeysPressedWord().ToLower() || word.text == GetKeysPressedWord())
        {
            print("Word entered correctly");
            KeysPressed.Clear();
            wordText.ResetHighlight();

            wordManager.AddWord(word);
            Destroy(transform.parent.gameObject);
            return;
        }
        else
        {
            // print($"thing: {GetKeysPressedWord()}");
        }

        // check if the current string of words is going the right way to compelete the word
        int currTLLen = KeysPressed.Count;

        for (int i = 0; i < currTLLen; i++)
        {
            if (word.text[i] != (char)KeysPressed[i])
            {
                print($"wrong KC word: {word.text[i]} KP: {KeysPressed[i]}");
                wordText.ResetHighlight();
                KeysPressed.Clear();
            }
        }
        // PrintKP();
        wordText.HighlightLetter(KeysPressed.Count);

    }

    private void PrintKP()
    {
        // KP == keys press
        print($"current TL: {GetKeysPressedWord()}");
    }

    private string GetKeysPressedWord()
    {
        string keys = "";

        foreach (KeyCode kcode in KeysPressed)
        {
            keys += KeyCodeToString(kcode);
        }

        return keys;
    }

    private string KeyCodeToString(KeyCode keyCode)
    {
        string keyString = keyCode.ToString();

        if (keyString.StartsWith("Alpha"))
        {
            return keyString.Replace("Alpha", "");
        }
        
        return keyString;
    }

}
