using UnityEngine;

[CreateAssetMenu(fileName = "Stats Data", menuName = "RocketData/Stats")]
public class StatsData : ScriptableObject
{
    public int maxLives;
    public int currentLives;

    public bool nearPlatform;
}
