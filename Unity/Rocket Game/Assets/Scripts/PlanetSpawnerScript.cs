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

    public GameEvent ePlanetSpawned;

    private void Awake()
    {
        //SpawnPlanet();
    }

    public void SpawnPlanet()
    {
        Vector2 newPosition = GetComponent<GameManagerScript>().lastVisitedPlanet.transform.position;

        newPosition.x = Random.Range(newPosition.x + 150, newPosition.x + 250);
        newPosition.y = Random.Range(newPosition.y + 25, newPosition.y - 25);

        newPlanet = Instantiate(prefabPlanet, newPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));

        ePlanetSpawned.Raise();
        gameData.planetsSpawned++;
    }
}

        //newPlanetPosition.position = newPosition;
        //GetComponent<GameManagerScript>().nextPlanet = newPlanet;