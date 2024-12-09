using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class movement : MonoBehaviour
{
    public float speed = 4f;
    public float controlMultiplier;
    public float horizontal;
    public float vertical;
    private Rigidbody2D rb;
    private Transform transform;
    void Start()
    {
        controlMultiplier = 1;
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        Rotation();
        horizontal = Input.GetAxisRaw("Horizontal")*controlMultiplier;
        vertical = Input.GetAxisRaw("Vertical")*controlMultiplier;
        rb.velocity = new Vector2(horizontal*speed, vertical*speed);
    }   
    private void Rotation()
    {
        Vector2 directPosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(directPosition);
        Vector2 lookDir = worldPosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
