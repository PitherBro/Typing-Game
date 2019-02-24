using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class wordGenerator
{
    
    static wordGenerator()
    {
        genList();
    }
    static List<string> easy = null,
                        medium = null,
                        hard = null;
    private static int easyThresh = 4, mediumThresh = 6;
    public static void genList()
    {
        //initializes the list of words
        easy = new List<string>();
        medium = new List<string>();
        hard = new List<string>();
        //reads file where data is stored
        StreamReader sr = new StreamReader("./Assets/words.txt");
        string data = sr.ReadLine().Trim();
        while ((data) != null)
        {
            addToRelativeList(ref data);
            data = sr.ReadLine();
        }

    }
    public static void addWord(string [] words)
    {
        for (int x =0; x < words.Length; x++)
        {
            addToRelativeList(ref words[0]);
        }
    }
    public static void addWord(string word)
    {
        addToRelativeList(ref word);
    }
    private static void addToRelativeList(ref string s)
    {
        if (s.Length <= easyThresh)
        {
            easy.Add(s);
        }
        else if (s.Length <= mediumThresh)
        {
            medium.Add(s);
        }
        else
        {
            hard.Add(s);
        }
    }
    public static string getRandomWord()
    {
        if (easy == null && medium == null && hard == null)
        {
            Debug.Log("loaded string List");
            genList();
        }
        return genWord();
    }
    private static string genWord()
    {

        string word = "";
        int selc = Random.Range(1, 3);
        switch (selc)
        {
            case 1:
                word = randomEasy();
                break;
            case 2:
                word = randomHard();
                break;
            case 3:
                word = randomMedium();
                break;
        }
        return word.ToLower();
    }

    public static string randomMedium()
    {
        string wrd = "";

        if (medium.Count - 1 > 0 && medium !=null)
        {
            wrd = medium[Random.Range(0, medium.Count - 1)];
            medium.Remove(wrd);
        }
        else
            medium = null;
        return wrd;
    }
    public static string randomHard()
    {
        string wrd = "";

        if (hard.Count - 1 > 0 && hard != null)
        {
            wrd = hard[Random.Range(0, hard.Count - 1)];
            hard.Remove(wrd);
        }
        else
            hard = null;
        return wrd;
    }
    public static string randomEasy()
    {
        string wrd = "";
        if (easy.Count - 1 > 0 && easy != null)
        {
            wrd = easy[Random.Range(0, easy.Count - 1)];
            easy.Remove(wrd);
        }
        else
            easy = null;
        return wrd;
    }

}
