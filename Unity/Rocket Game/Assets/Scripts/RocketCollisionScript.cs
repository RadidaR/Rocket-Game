using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollisionScript : MonoBehaviour
{
    public StatsData statsData;
    public InputData inputData;
    public MovementData movementData;
    public GameData gameData;

    public Rigidbody2D rb;
    public float damageVelocity;
    public Transform planetChecker;
    public LayerMask damagingLayer;

    
    public GameObject brokenRocket;

    public ParticleSystem explosion;
    public GameObject explosionEffector;

    public GameObject sprites;

    public GameObject currentPlanet;
    public float checkpointCounter;

    private void Awake()
    {
        statsData.currentLives = statsData.maxLives;
    }

    private void Update()
    {
        //RaycastHit2D platfromBelow = Physics2D.Raycast(rb.transform.position, planetChecker.position - rb.transform.position, 5, damagingLayer);

        //if (platfromBelow)
        //{
        //    Debug.Log(platfromBelow.distance.ToString());
        //    Debug.Log("damaging collider below");
        //}
        //else
        //{
        //    Debug.Log("nothing below");
        //}
    }

    private void Die()
    {
        if (statsData.currentLives > 0)
        {
            statsData.currentLives -= 1;

            rb.velocity = Vector2.zero;

            StartCoroutine(Explode());
        }
        else
        {
            statsData.currentLives += 1;
            Die();
        }

    }
    private void Respawn()
    {
        rb.gameObject.transform.position = gameData.lastPlatformPosition;
        rb.gameObject.transform.rotation = gameData.lastPlatformRotation;

        rb.constraints = RigidbodyConstraints2D.None;
        movementData.currentMainFuel = gameData.mainFuel;
        movementData.currentLeftFuel = gameData.leftFuel;
        movementData.currentRightFuel = gameData.rightFuel;

        inputData.mThrustInput = 0;
        inputData.lThrustInput = 0;
        inputData.rThrustInput = 0;
        inputData.lBreakInput = 0;
        inputData.rBreakInput = 0;

        GetComponent<EdgeCollider2D>().enabled = true;

        sprites.SetActive(true);
    }

    IEnumerator Explode()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<EdgeCollider2D>().enabled = false;

        explosionEffector.SetActive(true);
        sprites.SetActive(false);
        explosion.Play();
        GameObject brokenBits = Instantiate(brokenRocket, rb.gameObject.transform.position, rb.gameObject.transform.rotation);
        //brokenBits.transform.SetParent(null);
        //yield return new WaitForSecondsRealtime(0.35f);
        //rb.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        statsData.respawning = true;
        yield return new WaitForSecondsRealtime(0.5f);
        explosionEffector.SetActive(false);
        Respawn();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Die();
        }
        //if (Mathf.Abs(rb.velocity.x) > damageVelocity || Mathf.Abs(rb.velocity.y) > damageVelocity)
        //{
        //    Die();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            statsData.nearPlatform = true;

            //if (rb.velocity == Vector2.zero)
            //{
            //    currentPlanet = collision.gameObject.transform.parent.gameObject;
            //}
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            checkpointCounter -= Time.deltaTime;
            if (rb.velocity == Vector2.zero && rb.angularVelocity == 0)
            {
                RaycastHit2D platfromBelow = Physics2D.Raycast(rb.transform.position, planetChecker.position - rb.transform.position, 3, 7);

                if (platfromBelow && checkpointCounter <= 0)
                {
                    //gameData.lastPlatformPosition = rb.transform.position;
                    //gameData.lastPlatformRotation = rb.transform.rotation;
                    currentPlanet = collision.gameObject.transform.parent.gameObject.transform.parent.gameObject;

                    Debug.Log(collision.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.name.ToString());

                    gameData.lastPlatformPosition = collision.gameObject.transform.parent.transform.GetChild(1).transform.position;
                    gameData.lastPlatformRotation = collision.gameObject.transform.parent.transform.GetChild(1).transform.rotation;

                    gameData.mainFuel = movementData.currentMainFuel;
                    gameData.leftFuel = movementData.currentLeftFuel;
                    gameData.rightFuel = movementData.currentRightFuel;
                }
            }
            
            //if (rb.velocity == Vector2.zero)
            //{
                
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        statsData.nearPlatform = false;
        checkpointCounter = 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rb.gameObject.transform.position, planetChecker.position);
    }
}
