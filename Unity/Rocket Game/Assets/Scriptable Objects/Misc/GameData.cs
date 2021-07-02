using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Game/Data")]

public class GameData : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Respawn Values")]
    public Vector2 lastPlatformPosition;
    public Quaternion lastPlatformRotation;
    public float mainFuel;
    public float leftFuel;
    public float rightFuel;
    public int currentColors;

    public float extraFuel;
    public int fuelPickUp;

    [Header("Planet Spawn")]
    public int totalPlanets;
    public int planetsSpawned;
    public int randomX1;
    public int randomX2;
    public int randomY1;
    public int randomY2;

    [Header("Pick Ups")]
    [Range(0, 1)] public float startingLifePickUpChance;
    [Range(0, 1)] public float startingFuelPickUpChance;
    [Range(0, 1)] public float lifePickUpChance;
    [Range(0, 1)] public float fuelPickUpChance;

    public int[] difficultyLevels;
    public int easyDifficultyPlanetTotal;
    public int normalDifficultyPlanetTotal;
    public int hardDifficultyPlanetTotal;


    [Header("Win Condition")]
    public bool returning;

    public int currentScore;

    

    public void OnAfterDeserialize()
    {
        lastPlatformPosition = Vector2.zero;
        lastPlatformRotation = Quaternion.identity;
        mainFuel = 0;
        leftFuel = 0;
        rightFuel = 0;

        extraFuel = 0;

        planetsSpawned = 0;

        returning = false;


        currentScore = 0;
    }

    public void ResetValues()
    {
        lastPlatformPosition = Vector2.zero;
        lastPlatformRotation = Quaternion.identity;
        mainFuel = 0;
        leftFuel = 0;
        rightFuel = 0;

        extraFuel = 0;

        planetsSpawned = 0;

        returning = false;


        currentScore = 0;
    }
    public void OnBeforeSerialize()
    {
    }
}
