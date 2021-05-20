using UnityEngine;

[CreateAssetMenu(fileName = "Stats Data", menuName = "RocketData/Stats")]
public class StatsData : ScriptableObject, ISerializationCallbackReceiver
{
    public int maxLives;
    public int currentLives;

    public bool respawning;

    public bool nearPlatform;

    public void OnAfterDeserialize()
    {
        respawning = false;
    }
    public void OnBeforeSerialize()
    {
    }
}
