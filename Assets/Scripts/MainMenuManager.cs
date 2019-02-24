using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    private void Start()
    {
        wordManager.resetWordManager();
        GameManager.resetGameManager();
    }
    public void btnEasy()
    {
        GameManager.diff = 1;
        SceneManager.LoadScene(1);
    }
    public void btnMedium()
    {
        GameManager.diff = 2;
        SceneManager.LoadScene(1);
    }
    public void btnHard()
    {
        GameManager.diff = 3;
        SceneManager.LoadScene(1);
    }
    public void btnExpert()
    {
        GameManager.diff = 4;
        SceneManager.LoadScene(1);
    }

}
