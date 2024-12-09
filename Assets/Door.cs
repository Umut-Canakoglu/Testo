using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    private bool open = false;
    public LayerMask playerLayer;
    private BoxCollider2D collider;
    [SerializeField] private Tilemap map;
    [SerializeField] private TileBase openDoor;
    [SerializeField] private TileBase closeDoor;
    Vector2 colliderSize;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        colliderSize = collider.size;
    }
    void Update()
    {
        Collider2D[] playerCollider = Physics2D.OverlapBoxAll(transform.position, colliderSize/2, 0, playerLayer);
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E))
        {
            open = !open;
            collider.isTrigger = open;
        }
    }
    private void OnDrawGizmos()
    {
        Vector2 position = transform.position;
        Vector2 halfSize = colliderSize / 2;
        Vector2 topLeft = position + new Vector2(-halfSize.x, halfSize.y);
        Vector2 topRight = position + new Vector2(halfSize.x, halfSize.y);
        Vector2 bottomRight = position + new Vector2(halfSize.x, -halfSize.y);
        Vector2 bottomLeft = position + new Vector2(-halfSize.x, -halfSize.y);
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
