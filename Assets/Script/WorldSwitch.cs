using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{
    public int playerLayer;
    public int lightWallLayer;
    bool isLightWorld = true;
    public GameObject darkCanvas;
    public Timer timer;
    float switchCooldown = 1.0f;
    float lastSwitchTime;

    void Start()
    {
        ApplyWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastSwitchTime > switchCooldown)
        {
            isLightWorld = !isLightWorld;
            lastSwitchTime = Time.time;
            ApplyWorld();
        }
    }

    void ApplyWorld()
    {
        Physics2D.IgnoreLayerCollision(
            playerLayer,
            lightWallLayer,
            !isLightWorld
            );

        if (isLightWorld)
        {
            Camera.main.backgroundColor = Color.white;
            darkCanvas.SetActive(false);
        }
        else
        {
            Camera.main.backgroundColor = Color.black;
            darkCanvas.SetActive(true);
        }

        // É^ÉCÉÄÇÕèÌÇ…å©Ç¶ÇÈ
        timer.SetVisible(true);
    }
}
