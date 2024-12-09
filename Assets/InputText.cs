using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputText : MonoBehaviour
{
    public string randomGiven;
    private bool textEntry;
    private float timeCount;
    private float timeWait = 0;
    public GameObject bookCanvas;
    private bool startGiven;
    void  Awake()
    {
        startGiven = false;
        Time.timeScale = 1f;
        timeCount = 0;  
        textEntry = false;
    }
    void Update()
    {
        if (textEntry == true && bookCanvas.activeSelf == true)
        {
            timeCount = 0;
            timeWait = Random.Range(1f, 30f);
            bookCanvas.SetActive(false);
        }
        if (textEntry != true && bookCanvas.activeSelf == true)
        {
            timeCount += Time.deltaTime;
        }
        if (timeCount > 8f && bookCanvas.activeSelf == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        if (bookCanvas.activeSelf == false)
        {
            timeCount += Time.deltaTime;
        }
        if (bookCanvas.activeSelf == false && timeCount > timeWait && startGiven == true)
        {
            WriteTextController();
        }
    }
    public void WriteTextController()
    {
        textEntry = false;
        startGiven = true;
        timeCount = 0;
        string[] words = {"lol", "word", "hello", "what-up", "dude"," book", "berken", "bozkurt", "rc", "umut", "cool", "damn", "gamedev"};
        int randNum = Random.Range(0, words.Length);
        randomGiven = words[randNum];
        bookCanvas.SetActive(true);
        bookCanvas.GetComponentInChildren<TextMeshProUGUI>().text = randomGiven;
    }
    public void TextEnd(string entry)
    {  
        if (entry.ToLower() == randomGiven)
        {
            textEntry = true;
            Debug.Log(textEntry);
        }
        Debug.Log(textEntry);
    }
}
