using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    float elapsedTime;
    public bool isRunning = true;

    void Update()
    {
        if (!isRunning)return;
        elapsedTime += Time.deltaTime;
        int totalSeconds = Mathf.FloorToInt(elapsedTime);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timeText.text = minutes + ":" + seconds.ToString("00");
    }

    public void SetVisible(bool visible)
    {
        timeText.enabled = visible;
    }

    public string GetTimeString()
    {
        int totalSeconds = Mathf.FloorToInt(elapsedTime);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        return minutes + ":" + seconds.ToString("00");
    }

}
