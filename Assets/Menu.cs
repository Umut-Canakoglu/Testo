using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
        }
    }
}
