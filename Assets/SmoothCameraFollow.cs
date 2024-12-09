using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public float damping;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector3 movePosition = target.position + new Vector3(0, 0, -10);
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
