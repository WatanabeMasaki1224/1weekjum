using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Timer timer;
    public Text clearText;
    public Text clearTimeText;
    public GameObject fadePanel;
    public Button backToTitleButton; 


    private void Start()
    {
        // 最初は非表示
        fadePanel.SetActive(false);
        clearText.gameObject.SetActive(false);
        clearTimeText.gameObject.SetActive(false);
        backToTitleButton.gameObject.SetActive(false);

        // ボタンに関数を紐付け
        backToTitleButton.onClick.AddListener(BackToTitle);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        timer.isRunning = false;
        fadePanel.SetActive(true);
        clearText.gameObject.SetActive(true);
        clearTimeText.gameObject.SetActive(true);
        clearTimeText.text = timer.GetTimeString();
        backToTitleButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void BackToTitle()
    {
        Time.timeScale = 1f; // タイムスケール戻す
        SceneManager.LoadScene("Title"); // タイトルシーン名に置き換え
    }
}
