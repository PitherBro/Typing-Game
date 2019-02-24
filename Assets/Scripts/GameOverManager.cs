using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour {
    public Text correct, incorrect;
	// Use this for initialization
	void Start () {
        string [] text = GameManager.CompleteInfoFormated().Split('\t');
        string good = "", bad = "";
        for (int x=0; x < text.Length; x ++)
        {
            if (x % 2 == 0)
                good += text[x] + "\n";
            else
                bad += text[x] + "\n";
        }
        correct.text = good;
        incorrect.text = bad;
	}
    public void btnMenu()
    {
        Debug.Log("Clicked");
       SceneManager.LoadScene(0);
    }
    public void btnRestart()
    {
        GameManager.resetGameManager();
        wordManager.resetWordManager();
        SceneManager.LoadScene(1);
    }
}
