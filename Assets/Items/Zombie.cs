using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Zombie : MonoBehaviour
{
    public AIPath aiPath;
    private float timeLeft;
    private float timeMultiplier;
    private bool deathActive;
    private int currentDay;
    private int dayStorred;
    private GameObject playerObject;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aiPath.canMove = false;
        dayStorred = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().dayCount;
        currentDay = dayStorred;
        timeLeft = 60f;
    }
    void Update()
    {
        timeMultiplier = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeMultiplier;
        currentDay = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().dayCount;
        timeLeft -= Time.deltaTime*timeMultiplier;
        Debug.Log(timeLeft);
        if (timeLeft <= 0)
        {
            aiPath.canMove = true;
            deathActive = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Player")
        {
            Destroy(other.collider.gameObject);
        }
    }
}
