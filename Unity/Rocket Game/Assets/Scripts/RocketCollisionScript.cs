using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollisionScript : MonoBehaviour
{
    public StatsData statsData;
    public InputData inputData;
    public GameData gameData;

    public Rigidbody2D rb;
    public float damageVelocity;

    private void Awake()
    {
        statsData.currentLives = statsData.maxLives;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(rb.velocity.x) > damageVelocity || Mathf.Abs(rb.velocity.y) > damageVelocity)
        {

            statsData.currentLives -= 1;
            rb.gameObject.transform.position = gameData.lastPlatformPosition;
            rb.gameObject.transform.rotation = gameData.lastPlatformRotation;

            inputData.mThrustInput = 0;
            inputData.lThrustInput = 0;
            inputData.rThrustInput = 0;
            inputData.lBreakInput = 0;
            inputData.rBreakInput = 0;

            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            statsData.nearPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        statsData.nearPlatform = false;
    }
}
