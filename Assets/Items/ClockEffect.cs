using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockEffect : MonoBehaviour
{
    public void TimeSlow()
    {
        GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeMultiplier = 2f;
        Destroy(gameObject);
    }
}
