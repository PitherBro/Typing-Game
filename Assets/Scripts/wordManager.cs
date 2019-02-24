using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wordManager : MonoBehaviour {

    /*
    array of 26 words for each letter in alphabet, use list to fill array, could try setting capacity to 26 for list
        alternative, list with bool and char for alphabet, change bool based on words created.
    link wordGen functions to difficulty in addWord function
        1 = easy
        ...
        4 = any
            maybe have increase over time and increase time based on difficulty selected
    score screed to display final result.
        timed game, show accuracy and stats
    */
    public List<Word> words = new List<Word>();
    // public Word [] perminate = new Word[26];
    public int maxWords = 26;
    public static bool hasActiveWord;
    public Word activeWord;
    public WordSpawner wordSpawner;
    private void Start()
    {
        words.Capacity = 26;
       // AddWord();
       
    }
    private void Update()
    {
        //check every frame if we have a word that has exited the view
        if (words[0].display.transform.localPosition.y <= -220f)
        {
            //remove the word 
            //Debug.Log(words[0].text+" was Removed");            
            if (words[0].text == activeWord.text)
            {
                hasActiveWord = false;               
                activeWord = null;
            }
            words[0].display.RemoveWord();
            words.Remove(words[0]);
            GameManager.increaseWordsMissed();
            if (GameManager.lives <= 0)
                SceneManager.LoadScene(2);
            //shows stats in debug on missed word
            //Debug.Log(GameManager.CompleteInfoFormated());
        }
    }
    public void AddWord() 
    {
        //diffrent difficulty 
        WordDisplay wordDisplay = wordSpawner.SpawnWord();
        string wordText = getWordOnDiff();
        Word word;
        preventRepeatedLetters(ref wordText);
        word = new Word(wordText, wordDisplay);
        //Debug.Log(word.text);
        words.Add(word);
    }
    private void preventRepeatedLetters(ref string word)
    {
        //create word that does not share the same first letter with any other in list
        for (int x = 0; x < words.Count - 1; x++)
        {
            //check first letter
            if (words[x].text[0] == word[0])
            {
                Debug.Log("Found " + words[x].text + " matched " + word);
                //adds word back into list
                wordGenerator.addWord(word);
                //gets another random word
                word = getWordOnDiff();
                //reset the index to check list again
                x = 0;
            }
        }
    }
    private string getWordOnDiff()
    {
        
        switch (GameManager.diff)
        {
            case 1:
                return wordGenerator.randomEasy();
            case 2:
                return wordGenerator.randomMedium();
            case 3:
                return wordGenerator.randomHard();
            default:
                return wordGenerator.getRandomWord();              
        }
    }
    public void TypeLetter(char letter)
    {
        //Debug.Log(activeWord.display.transform.localPosition);
        //if we have an active word
        if (hasActiveWord)
        {
            //the next letter in the word is the same as the letter typed
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
                GameManager.increaseLettersTypedCorrectly();
            }
            //as long as the letter is not the pause button then a mistake was made
            else
            {
                if (letter != ' ')
                    GameManager.increaseLettersMissed();
            }
            //we hava an active word but it has been fully typed
            if (activeWord.wordTyped())
            {
                hasActiveWord = false;
                words.Remove(activeWord);
                GameManager.increaseWordsTyped();
                activeWord = null;
                if (GameManager.getWordsTyped() % GameManager.newLifeThreshold == 0 && GameManager.getWordsTyped() != 0)
                { GameManager.increaseLives(); }
            }
        }
        else
        {
            //searches through list of words for a letter that was typed if no word has been selected
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    //type letter
                    word.TypeLetter();
                    GameManager.increaseLettersTypedCorrectly();
                    break;
                }
            }
          
        }           
    }
    public static void resetWordManager()
    {
        hasActiveWord = false;
    }
}
