using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {


    public wordManager wordManager;
    public static float wordDely = 1.5f;
    private float nextWordline = 0f; 
    private int prevCompleteCount = GameManager.getWordsTyped(),
                prevIncorrectCount = GameManager.getWordsMissed();
    private float speedMultiplier = .99f;
    private void Start()
    {
        for (int x = 0;x < wordManager.maxWords+1; x++)
        {
            wordManager.AddWord();
            wordManager.words[x].display.GetComponent<GameObject>().SetActive(false);
        }
    }
    private void Update()
    {
        //spawns word in timed fashion as long as game is not paused
        if (Time.time >= nextWordline && !InputListener.isPaused)
        {
            if (wordManager.words.Count < wordManager.maxWords + 1)
                wordManager.AddWord();
            else
                wordManager.words[Random.Range(0, wordManager.maxWords)].display.GetComponent<GameObject>().SetActive(true);
            nextWordline = Time.time + wordDely;
            //will speed up as the player gets words right
            if (prevCompleteCount < GameManager.getWordsTyped())
            { 
                speedUpSpawn();
                prevCompleteCount = GameManager.getWordsTyped();
            }
            //speeds down if word is missed
            else if (prevIncorrectCount < GameManager.getWordsMissed())
            {
                slowDownSpawn();
                prevIncorrectCount = GameManager.getWordsMissed();
            }
        }
        //Debug.Log(wordManager.words[0].text+": "+ wordManager.words[0].display.transform.localPosition.y);        
    }
    private void speedUpSpawn()
    {
        wordDely *= speedMultiplier;
    }
    private void slowDownSpawn()
    {
        wordDely /= speedMultiplier;
    }
    
}
