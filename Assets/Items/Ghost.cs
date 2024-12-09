using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Rendering.Universal;
using System;


public class Ghost : MonoBehaviour
{
    public AIPath aiPath;
    Rigidbody2D rb;
    private GameObject playerObject;
    private Light2D light;
    private int dayBorn;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        light = playerObject.GetComponentInChildren<Light2D>();
        rb = GetComponent<Rigidbody2D>();
        GameObject solid = GameObject.FindGameObjectWithTag("solid");
        Physics2D.IgnoreCollision(solid.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        aiPath.canMove = false;
    }
    void Update()
    {
        Debug.Log(aiPath.canMove);
        if (IsObjectLit() == true)
        {
            aiPath.canMove = false;
        } else if (IsObjectLit() == false) {
            aiPath.canMove = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Player")
        {
            Destroy(other.collider.gameObject);
        }
    }
    private bool IsObjectLit()
    {
        Vector2 distanceVector = transform.position - playerObject.transform.position;
        float distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.y, 2));
        if (distance > light.pointLightOuterRadius)
        {
            return false;
        } else {
            Vector2 direction = distanceVector.normalized;
            Vector2 frontOfTheLight = playerObject.transform.right;
            float angleBetween = Vector2.Angle(frontOfTheLight, direction);
            if (angleBetween > light.pointLightOuterAngle/2)
            {
                return false;
            } else {
                RaycastHit2D[] hits = Physics2D.RaycastAll(playerObject.transform.position, direction, distance);
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject.tag == "Solid")
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
