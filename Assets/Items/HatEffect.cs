using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatEffect : MonoBehaviour
{
    
    public void ControlChange()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().controlMultiplier = -1f;
        Destroy(gameObject);
    }
}
