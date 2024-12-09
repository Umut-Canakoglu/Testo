using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float currentTime;
    private float timeLeft;
    public float timeMultiplier;
    void Start()
    {
        timeMultiplier = 1f;
        Time.timeScale = 1f;
    }
    void Update()
    {
        float customDeltaTime = Time.deltaTime * timeMultiplier;
        currentTime += customDeltaTime;
        timeLeft = 360.0f - currentTime;
        int minutes = Mathf.FloorToInt(timeLeft/60);
        int seconds = Mathf.FloorToInt(timeLeft%60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
