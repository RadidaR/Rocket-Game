using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollisionScript : MonoBehaviour
{
    public StatsData statsData;
    public InputData inputData;
    public MovementData movementData;
    public GameData gameData;
    public ColorLibrary colorLibrary;

    public Rigidbody2D rb;
    public float damageVelocity;
    public Transform planetChecker;
    public int damagingLayer;

    public int platformLayer;

    public int boundariesLayer;

    public int pickUpLayer;

    public int brokenRocketLayer;

    public float outOfBoundsTime;
    public float outOfBoundsCounter;

    
    public GameObject brokenRocket;

    public ParticleSystem explosion;
    public GameObject explosionEffector;

    public GameObject sprites;

    public GameObject currentPlanet;
    public float checkpointCounter;

    public GameEvent eFirstLand;
    public GameEvent eCheckPoint;
    public GameEvent eWin;
    public GameEvent eLose;
    public GameEvent eLostLife;
    public GameEvent eGainedLife;
    public GameEvent ePickedUpFuel;
    public GameEvent eSwitchColors;
    public GameEvent eExplode;
    public GameEvent eImpact;



    public GameManagerScript gameManager;

    bool coroutineRunning;

    private void Awake()
    {
        statsData.currentLives = statsData.startingLives;
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

        if (movementData.currentMainFuel <= 0)
        {
            if (movementData.currentLeftFuel <= 0 || movementData.currentRightFuel <= 0)
            {
                if (Mathf.Abs(rb.velocity.x) < 0.3f && Mathf.Abs(rb.velocity.y) < 0.3f)
                //if (rb.velocity == Vector2.zero)
                {
                    if (!statsData.respawning)
                    {
                        statsData.respawning = true;
                        sprites.SetActive(false);
                        LoseLife();
                        StartCoroutine(Respawn());
                    }
                }
            }
        }
    }

    private void LoseLife()
    {
        if (statsData.currentLives > 0)
        {
            statsData.currentLives -= 1;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<PolygonCollider2D>().enabled = false;
            outOfBoundsCounter = outOfBoundsTime;
            eLostLife.Raise();
        }
        else
        {
            eLose.Raise();
            //Debug.Log("Game Over");
        }
    }

    IEnumerator Respawn()
    {
        //int random = Random.Range(0, colorLibrary.rocketBodyColors.Length);
        //gameData.currentColors = random;
        yield return new WaitForSecondsRealtime(0.25f);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;

        inputData.mThrustInput = 0;
        inputData.lThrustInput = 0;
        inputData.rThrustInput = 0;
        inputData.lBreakInput = 0;
        inputData.rBreakInput = 0;

        //rb.position = gameData.lastPlatformPosition;
        //rb.SetRotation(gameData.lastPlatformRotation.z);

        rb.gameObject.transform.position = gameData.lastPlatformPosition;
        rb.gameObject.transform.rotation = gameData.lastPlatformRotation;

        rb.constraints = RigidbodyConstraints2D.None;

        movementData.currentMainFuel = gameData.mainFuel;
        movementData.currentLeftFuel = gameData.leftFuel;
        movementData.currentRightFuel = gameData.rightFuel;

        GetComponent<PolygonCollider2D>().enabled = true;
        sprites.SetActive(true);

        eSwitchColors.Raise();
        statsData.respawning = false;
    }

    IEnumerator Explode()
    {
        coroutineRunning = true;
        sprites.SetActive(false);
        eExplode.Raise();


        explosionEffector.SetActive(true);
        explosion.Play();
        GameObject pieces = Instantiate(brokenRocket, rb.gameObject.transform.position, rb.gameObject.transform.rotation);
        pieces.GetComponent<RocketColorScript>().SetColors();
        yield return new WaitForSecondsRealtime(0.5f);
        statsData.respawning = true;
        yield return new WaitForSecondsRealtime(0.5f);
        explosionEffector.SetActive(false);

        if (statsData.currentLives >= 0)
        {
            StartCoroutine(Respawn());
        }

        LoseLife();

        coroutineRunning = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == damagingLayer)
        {
            if (!coroutineRunning)
            {
                StartCoroutine(Explode());
            }
        }
        else if (collision.gameObject.layer == brokenRocketLayer)
        {
            eImpact.Raise();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == platformLayer)
        {
            statsData.nearPlatform = true;
        }

        if (collision.gameObject.layer == pickUpLayer)
        {
            if (collision.gameObject.tag == "Life")
            {
                if (statsData.currentLives < statsData.maxLives)
                {
                    statsData.currentLives += 1;
                    eGainedLife.Raise();
                }
                else
                {
                    gameData.currentScore += 20;
                }
                Destroy(collision.gameObject.GetComponent<PickUpPosition>().indicator);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Fuel")
            {
                gameData.extraFuel += gameData.fuelPickUp;
                ePickedUpFuel.Raise();
                Destroy(collision.gameObject.GetComponent<PickUpPosition>().indicator);
                Destroy(collision.gameObject);
            }

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
                    if (currentPlanet != collision.gameObject.transform.parent.gameObject.transform.parent.gameObject)
                    {
                        currentPlanet = collision.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        eCheckPoint.Raise();
                    }

                    if (currentPlanet == gameManager.nextPlanet)
                    {
                        if (gameManager.nextPlanet == gameManager.firstPlanet)
                        {
                            if (!gameManager.paused)
                            {
                                eWin.Raise();
                            }
                        }
                        else
                        {
                            eFirstLand.Raise();
                        }
                    }

                    statsData.canRefuel = true;
                }
            }
        }

        if (collision.gameObject.layer == boundariesLayer)
        {
            outOfBoundsCounter -= Time.deltaTime;
            if (outOfBoundsCounter <= 0)
            {
                LoseLife();
                StartCoroutine(Respawn());
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        statsData.nearPlatform = false;
        checkpointCounter = 0.5f;

        if (collision.gameObject.layer == boundariesLayer)
        {
            outOfBoundsCounter = outOfBoundsTime;
        }

        if (collision.gameObject.layer == platformLayer)
        {
            statsData.canRefuel = false;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(rb.gameObject.transform.position, planetChecker.position);
    //}
}
