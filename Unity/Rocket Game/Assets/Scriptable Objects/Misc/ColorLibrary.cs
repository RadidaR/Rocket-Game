using UnityEngine;

[CreateAssetMenu(fileName = "Color Library", menuName = "Game/Colors")]

public class ColorLibrary : ScriptableObject
{
    public Color[] planetColors1;
    public Color[] planetColors2;

    public Color[] rocketSludgeColors;
    public Color[] rocketBodyColors;
    public Color[] rocketPartsColors;
}
