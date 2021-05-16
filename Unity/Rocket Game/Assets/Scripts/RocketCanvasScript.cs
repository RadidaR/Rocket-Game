using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketCanvasScript : MonoBehaviour
{
    public MovementData movementData;

    public Slider mainTankSlider;
    public Slider leftTankSlider;
    public Slider rightTankSlider;

    private void OnValidate()
    {
    }

    void Start()
    {
        mainTankSlider.maxValue = movementData.mainTankMaxFuel;
        leftTankSlider.maxValue = movementData.sideTanksMaxFuel;
        rightTankSlider.maxValue = movementData.sideTanksMaxFuel;
    }

    void Update()
    {
        mainTankSlider.value = movementData.currentMainFuel;
        leftTankSlider.value = movementData.currentLeftFuel;
        rightTankSlider.value = movementData.currentRightFuel;
    }
}
