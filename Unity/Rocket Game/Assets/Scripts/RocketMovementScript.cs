using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RocketMovementScript : MonoBehaviour
{
    ActionMaps inputActions;

    
    [Header("Main Thruster")]
    float mainThrusterInput;
    public float mainThrusterForce;
    public float currentMainFuel;
    public float maxMainFuel;
    public float mainDrainRate;


    [Header("Side Thrusters")]
    float leftThrusterInput;
    float rightThrusterInput;
    public float sideThrusterForce;

    [Header("Breaks")]
    float leftBreakInput;
    float rightBreakInput;
    public float breakForce;

    [Header("Side Fuel")]
    public float currentLeftFuel;
    public float currentRightFuel;
    public float maxSideFuel;
    public float sideDrainRate;
    public float breakDrainRate;

    [Header("RigidBodies")]
    public Rigidbody2D mainThrusterRB;
    public Rigidbody2D leftThrusterRB;
    public Rigidbody2D rightThrusterRB;
    public Rigidbody2D leftBreakRB;
    public Rigidbody2D rightBreakRB;

    void Awake()
    {
        inputActions = new ActionMaps();

        inputActions.Gameplay.MainThruster.performed += ctx => mainThrusterInput = inputActions.Gameplay.MainThruster.ReadValue<float>();
        inputActions.Gameplay.MainThruster.canceled += ctx => mainThrusterInput = inputActions.Gameplay.MainThruster.ReadValue<float>();

        inputActions.Gameplay.LeftThruster.performed += ctx => leftThrusterInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();
        inputActions.Gameplay.LeftThruster.canceled += ctx => leftThrusterInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();

        inputActions.Gameplay.RightThruster.performed += ctx => rightThrusterInput = inputActions.Gameplay.RightThruster.ReadValue<float>();
        inputActions.Gameplay.RightThruster.canceled += ctx => rightThrusterInput = inputActions.Gameplay.RightThruster.ReadValue<float>();

        inputActions.Gameplay.LeftBreak.performed += ctx => leftBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>() * -1;
        inputActions.Gameplay.LeftBreak.canceled += ctx => leftBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>();

        inputActions.Gameplay.RightBreak.performed += ctx => rightBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>() * -1;
        inputActions.Gameplay.RightBreak.canceled += ctx => rightBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>();
    }

    private void Start()
    {
        currentMainFuel = maxMainFuel;
        currentLeftFuel = maxSideFuel;
        currentRightFuel = maxSideFuel;
    }

    void FixedUpdate()
    {
        if (mainThrusterInput != 0 || leftThrusterInput != 0 || rightThrusterInput != 0 || leftBreakInput != 0 || rightBreakInput != 0)
        {
            Move(mainThrusterRB, mainThrusterForce, mainThrusterInput, currentMainFuel);
            currentMainFuel = DrainFuel(currentMainFuel, mainDrainRate, mainThrusterInput);

            Move(leftThrusterRB, sideThrusterForce, leftThrusterInput, currentLeftFuel);
            currentLeftFuel = DrainFuel(currentLeftFuel, sideDrainRate, leftThrusterInput);

            Move(rightThrusterRB, sideThrusterForce, rightThrusterInput, currentRightFuel);
            currentRightFuel = DrainFuel(currentRightFuel, sideDrainRate, rightThrusterInput);

            Move(leftBreakRB, breakForce, leftBreakInput, currentLeftFuel);
            currentLeftFuel = DrainFuel(currentLeftFuel, breakDrainRate, leftBreakInput);

            Move(rightBreakRB, breakForce, rightBreakInput, currentRightFuel);
            currentRightFuel = DrainFuel(currentRightFuel, breakDrainRate, rightBreakInput);
        }        
    }

    void Move(Rigidbody2D rb, float force, float direction, float currentFuel)
    {
        if (currentFuel != 0)
        {
            rb.AddRelativeForce(Vector2.up * force * direction);
        }
    }

    float DrainFuel(float fuelDrained, float drainRate, float modifier)
    {
        if (fuelDrained > 0)
        {
            fuelDrained -= Time.fixedDeltaTime * drainRate * Mathf.Abs(modifier);
        }
        else
        {
            fuelDrained = 0;
        }
        return fuelDrained;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
