using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckEffect : MonoBehaviour
{
    public void AnnoyingSound()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().PlaySound("Duck");
        Destroy(gameObject);
    }
}
