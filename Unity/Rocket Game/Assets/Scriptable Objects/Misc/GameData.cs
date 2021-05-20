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

    [Header("Planet Spawn")]
    public int planetsSpawned;

    public void OnAfterDeserialize()
    {
        lastPlatformPosition = Vector2.zero;
        lastPlatformRotation = Quaternion.identity;
        mainFuel = 0;
        leftFuel = 0;
        rightFuel = 0;

        planetsSpawned = 0;
    }
    public void OnBeforeSerialize()
    {
    }
}
