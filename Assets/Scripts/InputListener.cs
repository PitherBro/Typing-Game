using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputListener : MonoBehaviour {

    // Update is called once per frame
    public wordManager wordManager;
    public Transform canvas;
    //public WordTimer WordTimer;
    public static bool isPaused = false;
	void Update ()
    {
        foreach (char letter in Input.inputString)
        {
            Debug.Log(letter);
                        
            //if the user pressed the spacebar then pause the game
            if (isPaused && letter == ' ')
            {
                canvas.gameObject.SetActive(true);
                //WordTimer.gameObject.SetActive(true);
                GameManager.playMusic();
                isPaused = false;
            }
            //if the user presses backspace, then return to main menu
            else if (isPaused && letter == '\b')
            {
                isPaused = false;
                SceneManager.LoadScene(0);
            }
            //if the user 
            else if (letter == ' ' && !isPaused)
            {
                canvas.gameObject.SetActive(false);
                //WordTimer.gameObject.SetActive(false);
                GameManager.pauseMusic();
                isPaused = true;
            }
            else
                //if the input is not a command it might be a letter
                wordManager.TypeLetter(letter);
        }
	}
}
