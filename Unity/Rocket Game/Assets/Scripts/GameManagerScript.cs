using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public StatsData statsData;
    public GameData gameData;
    public MovementData movementData;

    public GameObject rocketBody;
    public Rigidbody2D rocketRB;

    public PlanetSpawnerScript planetSpawner;
    public RocketCollisionScript rocketCollision;

    public GameObject firstPlanet;
    public GameObject lastVisitedPlanet;
    public GameObject nextPlanet;

    public Transform boundaries;

    public float totalTime;
    public float timeLeft;
    public bool timerRunning;

    public int score;

    public GameObject target;
    public GameObject checkPoint;

    public GameEvent eTimeToReturn;

    public bool paused = true;

    public GameEvent ePaused;
    public GameEvent eUnpaused;

    ActionMaps inputActions;

    public int storyModeScene;
    public int mainMenuScene;



    private void Awake()
    {
        inputActions = new ActionMaps();

        inputActions.Gameplay.Pause.performed += ctx => EscapePressed();

        Time.timeScale = 1;

        gameData.lifePickUpChance = gameData.startingLifePickUpChance;
        gameData.fuelPickUpChance = gameData.startingFuelPickUpChance;

    }

    private void Update()
    {
        if (!gameData.returning)
        {
            if (lastVisitedPlanet != null && nextPlanet != null)
            {
                boundaries.position = new Vector2((lastVisitedPlanet.transform.position.x + nextPlanet.transform.position.x) / 2,
                    (lastVisitedPlanet.transform.position.y + nextPlanet.transform.position.y) / 2);
            }
        }
        else
        {
            boundaries.position = new Vector2(rocketBody.transform.position.x, 300);
        }

        target.transform.position = nextPlanet.transform.GetChild(0).transform.GetChild(2).transform.position;
        target.transform.rotation = nextPlanet.transform.GetChild(0).transform.GetChild(2).transform.rotation;


    }

    public void EscapePressed()
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            PauseGame();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        paused = false;
        eUnpaused.Raise();

        //Debug.Log(PlayerPrefs.GetInt("Highscore"));
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
        ePaused.Raise();
    }

    public void Win()
    {
        Time.timeScale = 0f;
        paused = true;
        gameData.currentScore += (statsData.currentLives * 20) + Mathf.RoundToInt((gameData.planetsSpawned * 10) + Mathf.RoundToInt(timeLeft / 100) * (movementData.currentMainFuel + movementData.currentLeftFuel + movementData.currentRightFuel));
        if (PlayerPrefs.GetInt("Highscore") < gameData.currentScore)
        {
            PlayerPrefs.SetInt("Highscore", gameData.currentScore);
        }
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        paused = true;
        if (PlayerPrefs.GetInt("Highscore") < gameData.currentScore)
        {
            PlayerPrefs.SetInt("Highscore", gameData.currentScore);
        }
    }

    public void RestartGame()
    {
        //gameData.extraFuel = 0;
        //gameData.currentScore = 0;
        //gameData.planetsSpawned = 0;

        gameData.ResetValues();
        SceneManager.LoadScene(storyModeScene);
    }

    public void ReturnToMenu()
    {
        gameData.ResetValues();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void NewPlanet()
    {
        if (nextPlanet != null)
        {
            //Debug.Log("1 - From planets: " + Mathf.RoundToInt((gameData.planetsSpawned - 1) * 10).ToString());
            //Debug.Log("2 - Time: " + (timeLeft / 100).ToString() + " * Fuel: " + Mathf.RoundToInt((movementData.currentMainFuel + movementData.currentLeftFuel + movementData.currentRightFuel)).ToString());
            //Debug.Log("3 - Total: " + (Mathf.RoundToInt(((gameData.planetsSpawned - 1) * 10) + Mathf.RoundToInt(timeLeft / 100 * (movementData.currentMainFuel + movementData.currentLeftFuel + movementData.currentRightFuel)))).ToString());


            gameData.currentScore += Mathf.RoundToInt(((gameData.planetsSpawned - 1) * 10) + Mathf.RoundToInt(timeLeft/ 100 * (movementData.currentMainFuel + movementData.currentLeftFuel + movementData.currentRightFuel)));
        }

        timeLeft = totalTime;

        nextPlanet = planetSpawner.newPlanet;

        if (!timerRunning)
        {
            StartCoroutine(Timer());
        }

        if (nextPlanet == firstPlanet)
        {
            //Debug.Log("next and first match");
            gameData.returning = true;
            eTimeToReturn.Raise();
        }
    }




    public void CheckPoint()
    {
        if (rocketCollision.currentPlanet != null)
        {
            lastVisitedPlanet = rocketCollision.currentPlanet;

            gameData.lastPlatformPosition = lastVisitedPlanet.transform.GetChild(0).transform.GetChild(1).transform.position;
            gameData.lastPlatformRotation = lastVisitedPlanet.transform.GetChild(0).transform.GetChild(1).transform.rotation;

            checkPoint.transform.position = gameData.lastPlatformPosition;
            checkPoint.transform.rotation = gameData.lastPlatformRotation;

            checkPoint.GetComponent<Animator>().Play("Checkpoint Animation");

            gameData.mainFuel = movementData.currentMainFuel;
            gameData.leftFuel = movementData.currentLeftFuel;
            gameData.rightFuel = movementData.currentRightFuel;
        }
    }

    IEnumerator Timer()
    {
        timerRunning = true;

        while (timeLeft > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            if (!paused)
            {
                timeLeft -= 1;
            }

            if (!timerRunning)
            {
                break;
            }

            if (timeLeft <= 0)
            {
                break;
            }
        }
        timerRunning = false;
    }

    public void PlaySound(string soundName)
    {
        FindObjectOfType<AudioManager>().PlaySound(soundName);
    }

    public void StopSound(string soundName)
    {
        FindObjectOfType<AudioManager>().StopSound(soundName);
    }

    public void PlayRandomSound(string soundName)
    {
        FindObjectOfType<AudioManager>().PlayRandomSound(soundName);
    }



    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

}
