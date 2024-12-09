using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class TeddyBearEffect : MonoBehaviour
{
    private Transform playerPosition;
    private Vector3 spawnPoint;
    public GameObject ghost;
    private Vector3 positionDifference;
    public void TeddyBearMonsterSpawn()
    {   
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>().position;
        for (int i = 0; i < 2; i++)
        {
            positionDifference = new Vector3(0, i*6, 0);
            GameObject ghostClone = Instantiate(ghost, spawnPoint+positionDifference, Quaternion.identity);
            ghostClone.GetComponent<AIDestinationSetter>().target = playerPosition;
            float newSpeed = ((float)i / 2f);
            ghostClone.GetComponent<AIPath>().maxSpeed = newSpeed+1.5f;
        }
        Destroy(gameObject);
    }
}
