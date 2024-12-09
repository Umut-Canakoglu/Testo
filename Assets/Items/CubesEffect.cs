using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CubesEffect : MonoBehaviour
{
    private Transform playerPosition;
    private Vector3 spawnPoint;
    public GameObject deathMonster;
    public void CubeMonsterSpawn()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>().position;
        GameObject deathMonsterClone = Instantiate(deathMonster, spawnPoint, Quaternion.identity);
        deathMonsterClone.GetComponent<AIDestinationSetter>().target = playerPosition;
        Destroy(gameObject);
    }
}
