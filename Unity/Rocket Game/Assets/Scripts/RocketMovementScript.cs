using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RocketMovementScript : MonoBehaviour
{
    ActionMaps inputActions;

    public InputData inputData;
    public MovementData movementData;
    public StatsData statsData;

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

    public ParticleSystem[] mainThrusterParticles;

    //public GameEvent eMainThrusterActivated;
    //public GameEvent eSideThrusterActivated;

    void Awake()
    {
        inputActions = new ActionMaps();

        inputActions.Gameplay.MainThruster.performed += ctx => inputData.mThrustInput = inputActions.Gameplay.MainThruster.ReadValue<float>();
        inputActions.Gameplay.MainThruster.performed += ctx => FindObjectOfType<AudioManager>().PlaySound("audio_main_thruster");
        inputActions.Gameplay.MainThruster.canceled += ctx => inputData.mThrustInput = inputActions.Gameplay.MainThruster.ReadValue<float>();
        inputActions.Gameplay.MainThruster.canceled += ctx => StopMainParticles();
        inputActions.Gameplay.MainThruster.canceled += ctx => FindObjectOfType<AudioManager>().StopSound("audio_main_thruster");

        inputActions.Gameplay.LeftThruster.performed += ctx => inputData.lThrustInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();
        inputActions.Gameplay.LeftThruster.performed += ctx => PlaySideThrusterSound();
        inputActions.Gameplay.LeftThruster.canceled += ctx => inputData.lThrustInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();
        inputActions.Gameplay.LeftThruster.canceled += ctx => StopSideThrusterSound();
        inputActions.Gameplay.LeftThruster.canceled += ctx => leftThrusterParticle.Stop();

        inputActions.Gameplay.RightThruster.performed += ctx => inputData.rThrustInput = inputActions.Gameplay.RightThruster.ReadValue<float>();
        inputActions.Gameplay.RightThruster.performed += ctx => PlaySideThrusterSound();
        inputActions.Gameplay.RightThruster.canceled += ctx => inputData.rThrustInput = inputActions.Gameplay.RightThruster.ReadValue<float>();
        inputActions.Gameplay.RightThruster.canceled += ctx => StopSideThrusterSound();
        inputActions.Gameplay.RightThruster.canceled += ctx => rightThrusterParticle.Stop();

        inputActions.Gameplay.LeftBreak.performed += ctx => inputData.lBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>() * -1;
        inputActions.Gameplay.LeftBreak.performed += ctx => PlaySideThrusterSound();
        inputActions.Gameplay.LeftBreak.canceled += ctx => inputData.lBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>();
        inputActions.Gameplay.LeftBreak.canceled += ctx => StopSideThrusterSound();
        inputActions.Gameplay.LeftBreak.canceled += ctx => leftBreakParticle.Stop();

        inputActions.Gameplay.RightBreak.performed += ctx => inputData.rBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>() * -1;
        inputActions.Gameplay.RightBreak.performed += ctx => PlaySideThrusterSound();
        inputActions.Gameplay.RightBreak.canceled += ctx => inputData.rBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>();
        inputActions.Gameplay.RightBreak.canceled += ctx => StopSideThrusterSound();
        inputActions.Gameplay.RightBreak.canceled += ctx => rightBreakParticle.Stop();

        inputActions.Gameplay.Break.performed += ctx => inputData.rBreakInput = inputActions.Gameplay.Break.ReadValue<float>() * -1;
        inputActions.Gameplay.Break.performed += ctx => inputData.lBreakInput = inputActions.Gameplay.Break.ReadValue<float>() * -1;
        inputActions.Gameplay.Break.performed += ctx => PlaySideThrusterSound();
        inputActions.Gameplay.Break.canceled += ctx => inputData.rBreakInput = inputActions.Gameplay.Break.ReadValue<float>();
        inputActions.Gameplay.Break.canceled += ctx => inputData.lBreakInput = inputActions.Gameplay.Break.ReadValue<float>();
        inputActions.Gameplay.Break.canceled += ctx => StopSideThrusterSound();
        inputActions.Gameplay.Break.canceled += ctx => leftBreakParticle.Stop();
        inputActions.Gameplay.Break.canceled += ctx => rightBreakParticle.Stop();
    }

    private void Start()
    {        
        movementData.currentMainFuel = movementData.mainTankMaxFuel;
        movementData.currentLeftFuel = movementData.sideTanksMaxFuel;
        movementData.currentRightFuel = movementData.sideTanksMaxFuel;

        mainParticle.Stop();
        leftThrusterParticle.Stop();
        rightThrusterParticle.Stop();
        leftBreakParticle.Stop();
        rightBreakParticle.Stop();
    }

    void PlaySideThrusterSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("audio_side_thruster");
    }

    void StopSideThrusterSound()
    {
        FindObjectOfType<AudioManager>().StopSound("audio_side_thruster");
    }

    void FixedUpdate()
    {
        if (inputData.mThrustInput != 0)
        {
            //Move(mainThrusterRB, movementData.mainThrusterForce, inputData.mThrustInput, movementData.currentMainFuel, mainParticle);
            Move(mainThrusterRB, movementData.mainThrusterForce, inputData.mThrustInput, movementData.currentMainFuel, mainThrusterParticles[0]);
            movementData.currentMainFuel = DrainFuel(movementData.currentMainFuel, movementData.mainFuelDrainRate, inputData.mThrustInput);
        }
        else
        {
            StopMainParticles();
        }

        if (inputData.lThrustInput != 0)
        {
            Move(leftThrusterRB, movementData.sideThrustersForce, inputData.lThrustInput, movementData.currentLeftFuel, leftThrusterParticle);
            movementData.currentLeftFuel = DrainFuel(movementData.currentLeftFuel, movementData.sideFuelDrainRate, inputData.lThrustInput);
        }
        else
        {
            leftThrusterParticle.Stop();
        }

        if (inputData.rThrustInput != 0)
        {
            Move(rightThrusterRB, movementData.sideThrustersForce, inputData.rThrustInput, movementData.currentRightFuel, rightThrusterParticle);
            movementData.currentRightFuel = DrainFuel(movementData.currentRightFuel, movementData.sideFuelDrainRate, inputData.rThrustInput);
        }
        else
        {
            rightThrusterParticle.Stop();
        }

        if (inputData.lBreakInput != 0)
        {
            Move(leftBreakRB, movementData.breakThrustersForce, inputData.lBreakInput, movementData.currentLeftFuel, leftBreakParticle);
            movementData.currentLeftFuel = DrainFuel(movementData.currentLeftFuel, movementData.breakFuelDrainRate, inputData.lBreakInput);
        }
        else
        {
            leftBreakParticle.Stop();
        }

        if (inputData.rBreakInput != 0)
        { 
            Move(rightBreakRB, movementData.breakThrustersForce, inputData.rBreakInput, movementData.currentRightFuel, rightBreakParticle);
            movementData.currentRightFuel = DrainFuel(movementData.currentRightFuel, movementData.breakFuelDrainRate, inputData.rBreakInput);
        }     
        else
        {
            rightBreakParticle.Stop();
        }

        if (movementData.currentMainFuel <= 0)
        {
            StopMainParticles();
            FindObjectOfType<AudioManager>().StopSound("audio_main_thruster");
        }

        if (movementData.currentLeftFuel <= 0)
        {
            StopSideThrusterSound();
            leftThrusterParticle.Stop();
            leftBreakParticle.Stop();
        }

        if (movementData.currentRightFuel <= 0)
        {
            StopSideThrusterSound();
            rightThrusterParticle.Stop();
            rightBreakParticle.Stop();
        }
    }

    void StopMainParticles()
    {
        foreach (ParticleSystem particle in mainThrusterParticles)
        {
            particle.Stop();
        }
    }

    void Move(Rigidbody2D rb, float force, float direction, float currentFuel, ParticleSystem particles)
    {
        if (currentFuel != 0)
        {
            statsData.canRefuel = false;
            rb.AddRelativeForce(Vector2.up * force * direction);
            particles.Play();

            if (particles == mainThrusterParticles[0])
            {
                foreach (ParticleSystem particle in mainThrusterParticles)
                {
                    particle.Play();
                }
            }
        }
        else
        {
            particles.Stop();
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
