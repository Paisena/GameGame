using System;
using System.Collections.Generic;
using UnityEngine;

// TL means Typed Letters
// KC means Key Combo

public class KCListener : MonoBehaviour
{
    [SerializeField] List<KeyCode> KeysPressed;
    [SerializeField] WordManager wordManager;
    [SerializeField] Word word;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectKeyInputs();


    }

    void DetectKeyInputs()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                KeysPressed.Add(kcode);
            }
        }

        

        // print($"keys press are: {keys}");

        ValidateInputs();
    }

    void ValidateInputs()
    {
        // first check if word matches TL
        if (word.text == GetKeysPressedWord().ToLower())
        {
            print("Word entered correctly");
            return;
        }
        else
        {
            print($"thing: {GetKeysPressedWord()}");
        }

        // check if the current string of words is going the right way to compelete the word
        int currTLLen = KeysPressed.Count;

        for (int i = 0; i < currTLLen; i++)
        {
            if (word.text[i] != (char)KeysPressed[i])
            {
                print($"wrong KC word: {word.text[i]} KP: {KeysPressed[i]}");
                KeysPressed.Clear();
            }
            else
            {
                string keys = "";

                foreach (KeyCode kcode in KeysPressed)
                {
                    keys += kcode;
                }

                print($"current TL: {keys}");
            }
        }

    }

    private string GetKeysPressedWord()
    {
        string keys = "";

        foreach (KeyCode kcode in KeysPressed)
        {
            keys += kcode;
        }

        return keys;
    }


}
