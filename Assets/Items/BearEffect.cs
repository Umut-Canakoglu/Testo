using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEffect : MonoBehaviour
{
    public GameObject crazyMonster;
    public void CubeMonsterSpawn()
    {
        Invoke("Spawner", 30f);
    }
    private void Spawner()
    {
        Instantiate(crazyMonster, transform.position, Quaternion.identity);
    }
}
