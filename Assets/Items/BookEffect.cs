using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookEffect : MonoBehaviour
{
    public string randomGiven;
    private bool textEntry;
    private float timeCount;
    private GameObject bookCanvas;
    public void WriteText()
    {
        GameObject.FindGameObjectWithTag("BookController").GetComponent<InputText>().WriteTextController();
        Destroy(gameObject);
    }
}
