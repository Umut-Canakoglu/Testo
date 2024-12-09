using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SockMonster : MonoBehaviour
{
    private bool canSpawn;
    private GameObject playerObject;
    Vector2 zeroMovement = new Vector2(0, 0);
    private float timeCount;
    Renderer objRenderer;
    private Light2D light;
    void Awake()
    {
        light = GetComponentInChildren<Light2D>();
        canSpawn = true;
        objRenderer = gameObject.GetComponent<Renderer>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        timeCount = 0;
    }
    void Update()
    {
        if (timeCount >= 7f)
        {
            float randomWaitTime = Random.Range(20f, 50f);
            TemporarilyDestroy(gameObject, randomWaitTime);
        }
        if (objRenderer.enabled == true)
        {
            timeCount += Time.deltaTime;
        }
        if (objRenderer.enabled == true && playerObject.GetComponent<Rigidbody2D>().velocity != zeroMovement && canSpawn == true)
        {
            Destroy(playerObject);
        }
    }
    void TemporarilyDestroy(GameObject obj, float duration)
    {
        StartCoroutine(DisableTemporarily(obj, duration));
    }

    IEnumerator DisableTemporarily(GameObject obj, float duration)
    {
        timeCount = 0;
        objRenderer.enabled = false;
        light.intensity = 0f;
        canSpawn = false;
        yield return new WaitForSeconds(duration);
        float randXDiff = Random.Range(-3f, -1f);
        Vector3 difference = new Vector3(randXDiff, 0, 0);
        transform.position = playerObject.transform.position + difference;
        objRenderer.enabled = true; 
        light.intensity = 1f;
        yield return new WaitForSecondsRealtime(2f);
        canSpawn = true;
    }
}
