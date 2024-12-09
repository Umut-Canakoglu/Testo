using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeEffect : MonoBehaviour
{
    GameObject stainCanvas;
    public void StainsOnScreen()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>(true);
        foreach (Canvas canvas in canvases)
        {
            if (canvas.CompareTag("Stains"))
            {
                stainCanvas = canvas.gameObject;
                break;
            }
        }
        stainCanvas.SetActive(true);
    }
}
