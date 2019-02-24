using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

    public Text text;
    public float fallSpeed = 1;
    public void setWord(string word) { text.text = word; }
    public void RemoveLetter()
    {
        text.text = text.text.Remove(0,1);
        text.color = Color.blue;
    }
    public void RemoveWord()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate(0f,-fallSpeed * Time.deltaTime, 0);
    }
}
