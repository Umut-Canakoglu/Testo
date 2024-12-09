using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingEffect : MonoBehaviour
{
    public void PositionSwitch()
    {
        GameObject[] itesmCurrent = GameObject.FindGameObjectsWithTag("Item");
        Vector2[] allPositions = new Vector2[itesmCurrent.Length];
        for (int i = 0; i < itesmCurrent.Length; i++)
        {
            allPositions[i] = itesmCurrent[i].transform.position;
        }
        ReShuffleVectors(allPositions);
        for (int i = 0; i < itesmCurrent.Length; i++)
        {
            itesmCurrent[i].transform.position = allPositions[i];
        }
        Destroy(gameObject);
    }
    void ReShuffleVectors(Vector2[] vectors) 
    {
        for (int i = 0; i < vectors.Length; i++ )
        {
            Vector2 vector = vectors[i];
            int r = UnityEngine.Random.Range(i, vectors.Length);
            vectors[i] = vectors[r];
            vectors[r] = vector;
        }
    }

}
