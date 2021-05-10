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

    [Header("Side Thrusters")]
    float leftThrusterInput;
    float rightThrusterInput;
    public float sideThrusterForce;

    [Header("Breaks")]
    float leftBreakInput;
    float rightBreakInput;
    public float breakForce;

    [Header("Fuel")]
    public float currentMainFuel;
    public float maxMainFuel;
    public float mainDrainRate;
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

    [Header("Particles")]
    public ParticleSystem mainParticle;
    public ParticleSystem leftThrusterParticle;
    public ParticleSystem rightThrusterParticle;
    public ParticleSystem leftBreakParticle;
    public ParticleSystem rightBreakParticle;

    void Awake()
    {
        inputActions = new ActionMaps();

        inputActions.Gameplay.MainThruster.performed += ctx => mainThrusterInput = inputActions.Gameplay.MainThruster.ReadValue<float>();
        inputActions.Gameplay.MainThruster.canceled += ctx => mainThrusterInput = inputActions.Gameplay.MainThruster.ReadValue<float>();
        inputActions.Gameplay.MainThruster.canceled += ctx => mainParticle.Stop();

        inputActions.Gameplay.LeftThruster.performed += ctx => leftThrusterInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();
        inputActions.Gameplay.LeftThruster.canceled += ctx => leftThrusterInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();
        inputActions.Gameplay.LeftThruster.canceled += ctx => leftThrusterParticle.Stop();

        inputActions.Gameplay.RightThruster.performed += ctx => rightThrusterInput = inputActions.Gameplay.RightThruster.ReadValue<float>();
        inputActions.Gameplay.RightThruster.canceled += ctx => rightThrusterInput = inputActions.Gameplay.RightThruster.ReadValue<float>();
        inputActions.Gameplay.RightThruster.canceled += ctx => rightThrusterParticle.Stop();

        inputActions.Gameplay.LeftBreak.performed += ctx => leftBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>() * -1;
        inputActions.Gameplay.LeftBreak.canceled += ctx => leftBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>();
        inputActions.Gameplay.LeftBreak.canceled += ctx => leftBreakParticle.Stop();

        inputActions.Gameplay.RightBreak.performed += ctx => rightBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>() * -1;
        inputActions.Gameplay.RightBreak.canceled += ctx => rightBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>();
        inputActions.Gameplay.RightBreak.canceled += ctx => rightBreakParticle.Stop();
    }

    private void Start()
    {
        currentMainFuel = maxMainFuel;
        currentLeftFuel = maxSideFuel;
        currentRightFuel = maxSideFuel;

        mainParticle.Stop();
        leftThrusterParticle.Stop();
        rightThrusterParticle.Stop();
        leftBreakParticle.Stop();
        rightBreakParticle.Stop();
    }

    void FixedUpdate()
    {
        if (mainThrusterInput != 0)
        {
            Move(mainThrusterRB, mainThrusterForce, mainThrusterInput, currentMainFuel, mainParticle);
            currentMainFuel = DrainFuel(currentMainFuel, mainDrainRate, mainThrusterInput);
        }

        if (leftThrusterInput != 0)
        {
            Move(leftThrusterRB, sideThrusterForce, leftThrusterInput, currentLeftFuel, leftThrusterParticle);
            currentLeftFuel = DrainFuel(currentLeftFuel, sideDrainRate, leftThrusterInput);
        }

        if (rightThrusterInput != 0)
        {
            Move(rightThrusterRB, sideThrusterForce, rightThrusterInput, currentRightFuel, rightThrusterParticle);
            currentRightFuel = DrainFuel(currentRightFuel, sideDrainRate, rightThrusterInput);
        }

        if (leftBreakInput != 0)
        {
            Move(leftBreakRB, breakForce, leftBreakInput, currentLeftFuel, leftBreakParticle);
            currentLeftFuel = DrainFuel(currentLeftFuel, breakDrainRate, leftBreakInput);
        }

        if (rightBreakInput != 0)
        { 
            Move(rightBreakRB, breakForce, rightBreakInput, currentRightFuel, rightBreakParticle);
            currentRightFuel = DrainFuel(currentRightFuel, breakDrainRate, rightBreakInput);
        }        
    }

    void Move(Rigidbody2D rb, float force, float direction, float currentFuel, ParticleSystem fire)
    {
        if (currentFuel != 0)
        {
            rb.AddRelativeForce(Vector2.up * force * direction);
            fire.Play();
        }
        else
        {
            fire.Stop();
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
