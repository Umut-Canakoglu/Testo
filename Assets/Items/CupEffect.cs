using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CupEffect : MonoBehaviour
{
    public GameObject trap;
    public void TrapsSpawn()
    {
        GameObject[] roomsObjects = GameObject.FindGameObjectsWithTag("Room");
        Collider2D[] rooms = new Collider2D[roomsObjects.Length];
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i] = roomsObjects[i].GetComponent<Collider2D>();
        }
        int trapLeft = 6;
        int numOfTraps = 0;
        foreach (Collider2D room in rooms)
        {
            if (trapLeft == 0)
            {
                break;
            }
            int roomIndex = Array.IndexOf(rooms, room);
            if (roomIndex == rooms.Length-1)
            {
                numOfTraps = trapLeft;
            } else {
                numOfTraps = UnityEngine.Random.Range(0, trapLeft);
            }
            if (numOfTraps == 0 )
            {
                continue;
            }
            trapLeft -= numOfTraps;
            Rect[] regions = new Rect[numOfTraps];
            float regionWidth = (room.bounds.max.x - room.bounds.min.x) % numOfTraps;
            float regionHeight = (room.bounds.max.y - room.bounds.min.y) % numOfTraps;
            for (int i = 0; i < numOfTraps; i++)
            {
                Rect newRegion = new Rect(0, 0, 0, 0);
                bool isOverlapping = true;
                while (isOverlapping)
                {
                    float xMin = UnityEngine.Random.Range(room.bounds.min.x, room.bounds.max.x - regionWidth);
                    float yMin = UnityEngine.Random.Range(room.bounds.min.y, room.bounds.max.y - regionHeight);
                    newRegion = new Rect(xMin, yMin, regionWidth, regionHeight);
                    isOverlapping = false;
                    foreach (Rect region in regions)
                    {
                        if (newRegion == Rect.zero || newRegion.Overlaps(region))
                        {
                            isOverlapping = true;
                            break;
                        }
                    }
                }
                regions[i] = newRegion;
            }
            for (int i = 0; i < numOfTraps; i++)
            {
                float xPosition = UnityEngine.Random.Range(regions[i].xMin, regions[i].xMax);
                float yPosition = UnityEngine.Random.Range(regions[i].yMin, regions[i].yMax);
                Vector2 positionObject = new Vector2(xPosition, yPosition);
                Instantiate(trap, positionObject, Quaternion.identity);
            }   
        }
        Destroy(gameObject);
    }
}
