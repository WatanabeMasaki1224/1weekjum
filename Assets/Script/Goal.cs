using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Timer timer;
    public Text clearText;
    public Text clearTimeText;
    public GameObject fadePanel;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        timer.isRunning = false;
        fadePanel.SetActive(true);
        clearText.gameObject.SetActive(true);
        clearTimeText.gameObject.SetActive(true);
        clearTimeText.text = timer.GetTimeString();
        Time.timeScale = 0f;
    }
}
