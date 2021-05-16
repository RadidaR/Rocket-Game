using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Game/Data")]

public class GameData : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 lastPlatformPosition;
    public Quaternion lastPlatformRotation;

    public void OnAfterDeserialize()
    {
        lastPlatformPosition = Vector2.zero;
        lastPlatformRotation = Quaternion.identity;
    }
    public void OnBeforeSerialize()
    {
    }
}
