using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public StatsData statsData;
    public GameData gameData;

    public GameObject rocketBody;
    public Rigidbody2D rocketRB;

    private void Update()
    {
        if (statsData.nearPlatform)
        {
            if (rocketRB.velocity == Vector2.zero)
            {
                gameData.lastPlatformPosition = rocketBody.transform.position;
                gameData.lastPlatformRotation = rocketBody.transform.rotation;
            }
        }
    }
}
