using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockEffect : MonoBehaviour
{
    public GameObject sockMonster;
    public void SockMonsterSpawn()
    {
        float randXDiff = Random.Range(-3f, -2f);
        Vector3 difference = new Vector3(randXDiff, 0, 0);
        Instantiate(sockMonster, transform.position+difference, Quaternion.identity);
        Destroy(gameObject);
    }
}
