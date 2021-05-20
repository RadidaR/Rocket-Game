using UnityEngine;

[CreateAssetMenu(fileName = "Input Data", menuName = "RocketData/Input")]
public class InputData : ScriptableObject, ISerializationCallbackReceiver
{
    int reset = 0;
    [Range(0, 1)] public float mThrustInput;
    [Range(0, 1)] public float lThrustInput;
    [Range(0, 1)] public float rThrustInput;
    [Range(-1, 0)] public float lBreakInput;
    [Range(-1, 0)] public float rBreakInput;

    [Range(0, 1)] public float cameraControl;
    [Range(0, 1)] public float zoomIn;
    [Range(0, 1)] public float zoomOut;
    public void OnAfterDeserialize()
    {
        mThrustInput = reset;
        lThrustInput = reset;
        rThrustInput = reset;
        lBreakInput = reset;
        rBreakInput = reset;

        cameraControl = reset;
        zoomIn = reset;
        zoomOut = reset;
    }
    public void OnBeforeSerialize()
    {
    }
}
