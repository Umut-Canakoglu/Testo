using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbleEffect : MonoBehaviour
{
    public void SlowDown()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().speed -= 2f;
        Destroy(gameObject);
    }
}
