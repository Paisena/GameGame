using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WordText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] KCListener KeyListener;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupText()
    {
        text.text = KeyListener.word.text;
    }

    public void HighlightLetter(int index)
    {
        if (index <= 0)
        {
            return;
        }

        print($"highlighint letters {index}");

        string word = "<b>";

        for (int i = 0; i < KeyListener.word.text.Length; i++)
        {
            word += KeyListener.word.text[i];
            if (index == i)
            {
                word += "</b>";
            }

        }

        text.text = word;
    }

    public void ResetHighlight()
    {
        text.fontStyle = FontStyles.Normal;
        text.text = KeyListener.word.text;
    }

}
