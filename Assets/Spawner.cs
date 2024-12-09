using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEditorInternal.VersionControl;

public class Spawner : MonoBehaviour
{
    public GameObject[] allItems;
    public Collider2D[] rooms;
    public int dayCount = 5;
    public bool isActive = false;
    void Start()
    {
        if (isActive)
        {
            RandomlySpreadRoomByRoom(DetermineItemsOfDay(dayCount));
        }
    }
    void ReShuffleCollider(Collider2D[] cols) 
    {
        for (int i = 0; i < cols.Length; i++ )
        {
            Collider2D col = cols[i];
            int r = UnityEngine.Random.Range(i, cols.Length);
            cols[i] = cols[r];
            cols[r] = col;
        }
    }
    void ReShuffleGameObject(GameObject[] gameObjects) 
    {
        for (int i = 0; i < gameObjects.Length; i++ )
        {
            GameObject objectGame = gameObjects[i];
            int r = UnityEngine.Random.Range(i, gameObjects.Length);
            gameObjects[i] = gameObjects[r];
            gameObjects[r] = objectGame;
        }
    }
    private bool IsFoundGameObject(GameObject[] objects, GameObject thing)
    {
        bool isFound = false;
        foreach (GameObject gameObject in objects)
        {
            if (thing == gameObject)
            {
                isFound = true;
                break;
            }
        }
        return isFound;
    }
    private bool IsFoundInt(int[] nums, int num)
    {
        bool isFound = false;
        foreach (int integer in nums)
        {
            if (num == integer)
            {
                isFound = true;
                break;
            }
        }
        return isFound;
    }
    private void RandomlySpreadRoomByRoom(GameObject[] items)
    {
        int numOf = items.Length;
        int usableItems = numOf;
        int numOfItems;
        ReShuffleCollider(rooms);
        foreach (Collider2D room in rooms)
        {
            if (usableItems <= 0)
            {
                break;
            }
            int roomIndex = Array.IndexOf(rooms, room);
            if (roomIndex == (rooms.Length-1))
            {
                numOfItems = usableItems;
            } else {
                numOfItems = UnityEngine.Random.Range(0, usableItems);
            }
            if (numOfItems == 0 )
            {
                continue;
            }
            usableItems -= numOfItems;
            Rect[] regions = new Rect[numOfItems];
            GameObject[] itemsUsed = new GameObject[numOfItems];
            float regionWidth = ((room.bounds.max.x - room.bounds.min.x) % numOfItems) - 0.2f;
            float regionHeight = ((room.bounds.max.y - room.bounds.min.y) % numOfItems) - 0.2f;
            for (int i = 0; i < numOfItems; i++)
            {
                Rect newRegion = new Rect(0, 0, 0, 0);
                bool isOverlapping = true;
                int attempts = 0;
                while (isOverlapping && attempts < 5)
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
                    attempts ++;
                }
                regions[i] = newRegion;
            }
            if (roomIndex == (rooms.Length - 1))
            {
                int count = 0;
                foreach (GameObject itemGameObject in items)
                {
                    if (itemGameObject != null)
                    {
                        itemsUsed[count] = itemGameObject;
                        count ++;
                    }
                }
            } else {
                List<GameObject> availableItems = new List<GameObject>();
                for (int i = 0; i < numOfItems; i++)
                {
                    if (items[i] != null)
                    {
                        availableItems.Add(items[i]);
                    }
                }
                Debug.Log(numOfItems);
                foreach (GameObject ListItem in availableItems)
                {
                    Debug.Log(ListItem);
                }
                GameObject[] usableGameObjects = availableItems.ToArray();
                ReShuffleGameObject(usableGameObjects);
                for (int i = 0; i < numOfItems; i++)
                {
                    itemsUsed[i] = usableGameObjects[i];
                    items[Array.IndexOf(items, usableGameObjects[i])] = null;
                }
            
            }
            ReShuffleGameObject(itemsUsed);
            for (int i = 0; i < numOfItems; i++)
            {
                float xPosition = UnityEngine.Random.Range(regions[i].xMin, regions[i].xMax);
                float yPosition = UnityEngine.Random.Range(regions[i].yMin, regions[i].yMax);
                Vector2 positionObject = new Vector2(xPosition, yPosition);
                Instantiate(itemsUsed[i], positionObject, Quaternion.identity);
            }  
        }
    }
    private GameObject[] DetermineItemsOfDay(int theDay)
    {
        theDay ++;
        int itemCount = Mathf.Min(theDay*2, allItems.Length);
        GameObject[] itemsArray = new GameObject[itemCount];
        GameObject[] unshuffledList = allItems;
        ReShuffleGameObject(allItems);
        GameObject[] shuffledList = allItems;
        allItems = unshuffledList;
        for (int i = 0; i < itemCount; i++)
        {
            itemsArray[i] = shuffledList[i];
        }
        return itemsArray;
    }
}
