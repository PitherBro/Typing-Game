using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    private static int wordsTyped = 0, 
                       wordsMissed = 0, 
                       lettersMissTyped = 0, 
                       lettersTypedCorrectly = 0;
    public static int diff = 1;
    public static int lives = 3;
    public static int newLifeThreshold = 5 * diff;

   
    public Text Display;

    public GameObject audioPrefab;
    private static AudioSource Music;
    //GameObject audioPlayer;
    // Use this for initialization
    void Start()
    {
       
        GameObject temp = Instantiate(audioPrefab);
        Music = temp.GetComponent<AudioSource>();
        if (Music.clip.LoadAudioData())
            Music.Play();
        else
            Debug.Log("failed to load Music Data");
        //Debug.Log("Diff is: " + diff);
        newLifeThreshold = 5 * diff;
    }
    public static string CompleteInfoFormated() {

        string info = string.Format("Complete Words: {0}\tMissed Words: {1}\nCorrect Letters: {2}\tMissed Letters: {3}\nTotal Letters: {4}\tAccuracy: {5}", wordsTyped, wordsMissed,  lettersTypedCorrectly, lettersMissTyped,calcTotalLettersTyped(),calcLetterAccuracy());
        return info;
    }
    
    public static int calcTotalLettersTyped()
    {
       
        return lettersTypedCorrectly + lettersMissTyped;
    }
    public static decimal calcLetterAccuracy()
    {
        decimal total = calcTotalLettersTyped();
        
        return decimal.Round((((decimal) lettersTypedCorrectly / total)*(decimal) 100),2);
    }
    public static void increaseWordsTyped() { wordsTyped += 1; }
    public static void increaseWordsMissed() { wordsMissed += 1; lives -= 1; }
    public static void increaseLettersMissed() { lettersMissTyped += 1; }
    public static void increaseLettersTypedCorrectly() { lettersTypedCorrectly += 1; }
    public static int getWordsTyped() { return wordsTyped; }
    public static int getWordsMissed() { return wordsMissed; }
    public static int getLettersMissTyped() { return lettersMissTyped; }
    public static int getLettersTypedCorrectly() { return lettersTypedCorrectly; }
    // Update is called once per frame
    void Update ()
    {
        Display.text = "Lives: "+ lives.ToString();
        if (lives <= 0)
        {
            
        }
	}
    public static void pauseMusic()
    {
        Music.Pause();
    }
    public static void playMusic()
    {
        Music.Play();
    }
    public static void increaseLives()
    {
        lives += 1;
    }
    public static void resetGameManager()
    {
        wordManager.hasActiveWord = false;
        lives = 3;
        wordsTyped = 0;
        wordsMissed = 0;
        lettersMissTyped = 0;
        lettersTypedCorrectly = 0;
    }
   
}
