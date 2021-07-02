using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformFuelScript : MonoBehaviour
{
    public float totalFuel;
    public float currentFuel;

    public Slider fuelSlider;


    // Start is called before the first frame update
    void Start()
    {
        fuelSlider.maxValue = totalFuel;
        currentFuel = totalFuel;
    }

    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = currentFuel;
    }
}
