using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketCanvasScript : MonoBehaviour
{
    RocketMovementScript moveScript;

    public Slider mainTankSlider;
    public Slider leftTankSlider;
    public Slider rightTankSlider;

    private void OnValidate()
    {
        if (gameObject.activeInHierarchy)
        {
            moveScript = GetComponent<RocketMovementScript>();
        }
    }
    void Start()
    {
        mainTankSlider.maxValue = moveScript.maxMainFuel;
        leftTankSlider.maxValue = moveScript.maxSideFuel;
        rightTankSlider.maxValue = moveScript.maxSideFuel;
    }

    void Update()
    {
        mainTankSlider.value = moveScript.currentMainFuel;
        leftTankSlider.value = moveScript.currentLeftFuel;
        rightTankSlider.value = moveScript.currentRightFuel;
    }
}
