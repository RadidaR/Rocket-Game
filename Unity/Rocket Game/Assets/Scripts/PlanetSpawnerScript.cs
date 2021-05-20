using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnerScript : MonoBehaviour
{
    public GameObject prefabPlanet;

    public Transform lastPlanetPosition;
    public Transform newPlanetPosition;

    public GameData gameData;

    public GameObject newPlanet;

    private void Awake()
    {
        SpawnPlanet();
    }

    private void SpawnPlanet()
    {
        Vector2 newPosition = lastPlanetPosition.position;

        newPosition.x = Random.Range(newPosition.x + 100, newPosition.x + 150);
        newPosition.y = Random.Range(newPosition.y + 75, newPosition.y - 75);

        newPlanetPosition.position = newPosition;

        newPlanet = Instantiate(prefabPlanet, newPlanetPosition);

        gameData.planetsSpawned++;
    }
}
