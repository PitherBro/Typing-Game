using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Word
{
    //TextMeshPro
    public string text;
    int index;
    public WordDisplay display;
    public Word(string s, WordDisplay display)
    {
        text = s.ToLower();
        index = 0;
        this.display = display;
        display.setWord(text);
    }
    public char GetNextLetter()
    {
        return text[index];
    }
    public void TypeLetter()
    {
        index++;
        //remove the letter on screen
        display.RemoveLetter();
    }
    public bool wordTyped()
    {
       
        bool wordTyped = (index >= text.Length);
        if (wordTyped)
        {
            //remove word on screen
            display.RemoveWord();
            
        }
        
        return wordTyped;
    }
}
