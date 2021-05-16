using UnityEngine;

[CreateAssetMenu(fileName = "Movement Data", menuName = "RocketData/Movement")]
public class MovementData : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Thruster Forces")]
    public float mainThrusterForce;
    public float sideThrustersForce;
    public float breakThrustersForce;

    [Header("Current Fuel")]
    public float currentMainFuel;
    public float currentLeftFuel;
    public float currentRightFuel;

    [Header("Max Fuel Tanks")]
    public float mainTankMaxFuel;
    public float sideTanksMaxFuel;

    [Header("Fuel Drain Rates")]
    public float mainFuelDrainRate;
    public float sideFuelDrainRate;
    public float breakFuelDrainRate;

    public void OnAfterDeserialize()
    {
        currentMainFuel = 0;
        currentLeftFuel = 0;
        currentRightFuel = 0;
    }

    public void OnBeforeSerialize()
    {

    }
}
