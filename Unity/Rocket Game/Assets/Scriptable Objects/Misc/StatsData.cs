using UnityEngine;

[CreateAssetMenu(fileName = "Stats Data", menuName = "RocketData/Stats")]
public class StatsData : ScriptableObject, ISerializationCallbackReceiver
{
    public int maxLives;
    public int startingLives;
    public int currentLives;

    public bool respawning;

    public bool nearPlatform;

    public bool canRefuel;


    public void OnAfterDeserialize()
    {
        respawning = false;
        nearPlatform = false;
        canRefuel = false;
    }
    public void OnBeforeSerialize()
    {
    }
}
