using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 Direction(this Vector2 origin, Vector2 destination)
    {
        Vector2 direction = destination - origin;
        return direction.normalized;
    }
}
