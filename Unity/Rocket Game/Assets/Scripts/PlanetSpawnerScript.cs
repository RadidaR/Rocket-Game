using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnerScript : MonoBehaviour
{
    public GameObject prefabPlanet;

    //public Transform lastPlanetPosition;
    //public Transform newPlanetPosition;

    public GameData gameData;

    public GameObject newPlanet;

    public GameObject lifePickUp;
    public GameObject fuelPickUp;

    public GameObject[] easyObstacles;
    public GameObject[] mediumObstacles;
    public GameObject[] hardObstacles;

    public float startPlanetHeight;

    public GameEvent ePlanetSpawned;

    //public int numberOfPlanets;

    private void Awake()
    {
        startPlanetHeight = GetComponent<GameManagerScript>().firstPlanet.transform.position.y;
    }
    public void SpawnPlanet()
    {
        Vector2 lastVisitedPosition = GetComponent<GameManagerScript>().lastVisitedPlanet.transform.position;
        Vector2 newPosition = lastVisitedPosition;

        newPosition.x = Random.Range(newPosition.x + gameData.randomX1, newPosition.x + gameData.randomX2);
        newPosition.y = Random.Range(startPlanetHeight + gameData.randomY1, startPlanetHeight - gameData.randomY2);

        if (gameData.planetsSpawned < gameData.totalPlanets)
        {
            if (gameData.planetsSpawned < 1)
            {
                newPlanet = Instantiate(prefabPlanet, newPosition, Quaternion.identity);
            }
            else if (gameData.planetsSpawned < 3)
            {
                newPlanet = Instantiate(prefabPlanet, newPosition, Quaternion.Euler(0, 0, Random.Range(gameData.planetsSpawned * -30, gameData.planetsSpawned * 30)));
            }
            else if (gameData.planetsSpawned < 5)
            {
                newPlanet = Instantiate(prefabPlanet, newPosition, Quaternion.Euler(0, 0, Random.Range(gameData.planetsSpawned * -50, gameData.planetsSpawned * 50)));
            }
            else
            {
                newPlanet = Instantiate(prefabPlanet, newPosition, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            }

            gameData.planetsSpawned++;

            float averageX = (lastVisitedPosition.x + newPosition.x) / 2;


            float obstacleY = (lastVisitedPosition.y + newPosition.y) / 2; 

            int randomHeight = Random.Range(0, 3);

            if (randomHeight == 1)
            {
                obstacleY += 30;
            }
            else if (randomHeight == 2)
            {
                obstacleY -= 30;
            }

            if (gameData.planetsSpawned <= gameData.difficultyLevels[0])
            {
                Instantiate(easyObstacles[Random.Range(0, easyObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
            }
            else if (gameData.planetsSpawned <= gameData.difficultyLevels[1])
            {
                Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
            }
            else
            {
                obstacleY = (lastVisitedPosition.y + newPosition.y) / 2;
                if (gameData.planetsSpawned <= gameData.difficultyLevels[2])
                {
                    Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
                    
                    randomHeight = Random.Range(0, 2);
                    if (randomHeight == 0)
                    {
                        obstacleY += 60;
                    }
                    else if (randomHeight == 1)
                    {
                        obstacleY -= 45;
                    }
                    Instantiate(easyObstacles[Random.Range(0, easyObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
                }
                else if (gameData.planetsSpawned <= gameData.difficultyLevels[3])
                {
                    Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);

                    randomHeight = Random.Range(0, 2);
                    if (randomHeight == 0)
                    {
                        obstacleY += 60;
                    }
                    else if (randomHeight == 1)
                    {
                        obstacleY -= 45;
                    }
                    Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
                }
                else if (gameData.planetsSpawned <= gameData.difficultyLevels[4])
                {
                    Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);

                    randomHeight = Random.Range(0, 2);
                    if (randomHeight == 0)
                    {
                        obstacleY += 60;
                    }
                    else if (randomHeight == 1)
                    {
                        obstacleY -= 45;
                    }
                    Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
                }
                else if (gameData.planetsSpawned <= gameData.difficultyLevels[5])
                {
                    Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);

                    int random = Random.Range(0, 2);

                    if (random == 0)
                    {
                        Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY + 60, 0), Quaternion.identity);
                        Instantiate(easyObstacles[Random.Range(0, easyObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY - 45, 0), Quaternion.identity);
                    }
                    else if (random == 1)
                    {
                        Instantiate(easyObstacles[Random.Range(0, easyObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY + 60, 0), Quaternion.identity);
                        Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY - 45, 0), Quaternion.identity);
                    }
                }
                else if (gameData.planetsSpawned <= gameData.difficultyLevels[6])
                {
                    Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
                    Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY + 60, 0), Quaternion.identity);
                    Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY - 45, 0), Quaternion.identity);
                }
                else if (gameData.planetsSpawned <= gameData.difficultyLevels[7])
                {
                    Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);

                    int random = Random.Range(0, 2);

                    if (random == 0)
                    {
                        Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY + 60, 0), Quaternion.identity);
                        Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY - 45, 0), Quaternion.identity);
                    }
                    else if (random == 1)
                    {
                        Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY + 60, 0), Quaternion.identity);
                        Instantiate(mediumObstacles[Random.Range(0, mediumObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY - 45, 0), Quaternion.identity);
                    }

                }
                else
                {
                    Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY, 0), Quaternion.identity);
                    Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY + 60, 0), Quaternion.identity);
                    Instantiate(hardObstacles[Random.Range(0, hardObstacles.Length)], new Vector3(Random.Range(averageX - 30, averageX + 30), obstacleY - 45, 0), Quaternion.identity);
                }
            }

            if (gameData.planetsSpawned > 1)
            {
                float randomChance = Random.Range(0f, 1f);

                if (randomChance <= gameData.lifePickUpChance)
                {
                    Instantiate(lifePickUp, new Vector3(Random.Range(averageX - 25, averageX + 25), Random.Range(obstacleY - 25, obstacleY + 25), 0), Quaternion.identity);
                }

                randomChance = Random.Range(0f, 1f);

                if (randomChance <= gameData.fuelPickUpChance)
                {
                    Instantiate(fuelPickUp, new Vector3(Random.Range(averageX - 25, averageX + 25), Random.Range(obstacleY - 25, obstacleY + 25), 0), Quaternion.identity);
                }
            }



        }
        else
        {
            newPlanet = GetComponent<GameManagerScript>().firstPlanet;
        }

        if (gameData.fuelPickUpChance < 1)
        {
            gameData.fuelPickUpChance += 0.05f;
        }

        gameData.lifePickUpChance += 0.01f;
        ePlanetSpawned.Raise();


    }
}

        //newPlanetPosition.position = newPosition;
        //GetComponent<GameManagerScript>().nextPlanet = newPlanet;