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
    public int platformLayer;

    
    public GameObject brokenRocket;

    public ParticleSystem explosion;
    public GameObject explosionEffector;

    public GameObject sprites;

    public GameObject currentPlanet;
    public float checkpointCounter;

    public GameEvent eFirstLand;
    public GameEvent eCheckPoint;
    public GameManagerScript gameManager;

    bool coroutineRunning;

    private void Awake()
    {
        statsData.currentLives = statsData.maxLives;
        eFirstLand.Raise();
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
            if (!coroutineRunning)
            {
                statsData.currentLives -= 1;

                rb.velocity = Vector2.zero;

                StartCoroutine(Explode());
            }
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

        GetComponent<PolygonCollider2D>().enabled = true;

        sprites.SetActive(true);
    }

    IEnumerator Explode()
    {
        coroutineRunning = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<PolygonCollider2D>().enabled = false;

        explosionEffector.SetActive(true);
        sprites.SetActive(false);
        explosion.Play();
        Instantiate(brokenRocket, rb.gameObject.transform.position, rb.gameObject.transform.rotation);
        yield return new WaitForSecondsRealtime(0.5f);
        statsData.respawning = true;
        yield return new WaitForSecondsRealtime(0.75f);
        explosionEffector.SetActive(false);
        Respawn();
        coroutineRunning = false;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
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
        if (collision.gameObject.layer == platformLayer)
        {
            if (Mathf.Abs(rb.velocity.x) < 0.5f && Mathf.Abs(rb.velocity.y) < 0.5f)
            {
                RaycastHit2D platfromBelow = Physics2D.Raycast(rb.transform.position, planetChecker.position - rb.transform.position, 3, damagingLayer);

                if (platfromBelow)
                { 
                    currentPlanet = collision.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                    eCheckPoint.Raise();

                    if (currentPlanet == gameManager.nextPlanet)
                    {                        
                        eFirstLand.Raise();
                    }
                }
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        statsData.nearPlatform = false;
        checkpointCounter = 0.5f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rb.gameObject.transform.position, planetChecker.position);
    }
}
