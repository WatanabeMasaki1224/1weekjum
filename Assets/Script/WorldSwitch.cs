using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{
    public int playerLayer;
    public int lightWallLayer;
    bool isLightWorld = true;

    void Start()
    {
        ApplyWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            isLightWorld = !isLightWorld;
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

        Camera.main.backgroundColor = isLightWorld ? Color.white : Color.black;
    }
}
