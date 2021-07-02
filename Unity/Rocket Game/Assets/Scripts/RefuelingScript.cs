using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelingScript : MonoBehaviour
{
    public MovementData movementData;
    public InputData inputData;
    public StatsData statsData;
    public GameData gameData;

    public GameManagerScript gameManager;

    public float refuellingSpeed;

    ActionMaps inputActions;

    public GameEvent eRefueling;

    bool refuelling;

    private void Awake()
    {
        inputActions = new ActionMaps();

        inputActions.Gameplay.Refuel.performed += ctx => inputData.refuelInput = inputActions.Gameplay.Refuel.ReadValue<float>();
        inputActions.Gameplay.Refuel.canceled += ctx => inputData.refuelInput = inputActions.Gameplay.Refuel.ReadValue<float>();

        inputActions.Gameplay.RefuelMainTank.performed += ctx => inputData.mainTank = inputActions.Gameplay.RefuelMainTank.ReadValue<float>();
        inputActions.Gameplay.RefuelMainTank.canceled += ctx => inputData.mainTank = inputActions.Gameplay.RefuelMainTank.ReadValue<float>();

        inputActions.Gameplay.RefuelLeftTank.performed += ctx => inputData.leftTank = inputActions.Gameplay.RefuelLeftTank.ReadValue<float>();
        inputActions.Gameplay.RefuelLeftTank.canceled += ctx => inputData.leftTank = inputActions.Gameplay.RefuelLeftTank.ReadValue<float>();

        inputActions.Gameplay.RefuelRightTank.performed += ctx => inputData.rightTank = inputActions.Gameplay.RefuelRightTank.ReadValue<float>();
        inputActions.Gameplay.RefuelRightTank.canceled += ctx => inputData.rightTank = inputActions.Gameplay.RefuelRightTank.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if (statsData.canRefuel)
        {
            PlatformFuelScript platform = gameManager.lastVisitedPlanet.GetComponentInChildren<PlatformFuelScript>();

            if (platform.currentFuel > 0)
            {
                if (inputData.refuelInput != 0)
                {
                    if (inputData.mainTank != 0 && movementData.currentMainFuel < movementData.mainTankMaxFuel)
                    {
                        platform.currentFuel -= Time.deltaTime * refuellingSpeed;
                        Refuel();
                        if (platform.currentFuel <= 0)
                        {
                            FindObjectOfType<AudioManager>().StopSound("audio_refueling");
                            refuelling = false;
                        }
                        movementData.currentMainFuel += Time.deltaTime * refuellingSpeed;
                    }
                    else if (inputData.leftTank != 0 && movementData.currentLeftFuel < movementData.sideTanksMaxFuel)
                    {
                        platform.currentFuel -= Time.deltaTime * refuellingSpeed;
                        Refuel();
                        if (platform.currentFuel <= 0)
                        {
                            FindObjectOfType<AudioManager>().StopSound("audio_refueling");
                            refuelling = false;
                        }
                        movementData.currentLeftFuel += Time.deltaTime * refuellingSpeed;
                    }
                    else if (inputData.rightTank != 0 && movementData.currentRightFuel < movementData.sideTanksMaxFuel)
                    {
                        platform.currentFuel -= Time.deltaTime * refuellingSpeed;
                        Refuel();
                        if (platform.currentFuel <= 0)
                        {
                            FindObjectOfType<AudioManager>().StopSound("audio_refueling");
                            refuelling = false;
                        }
                        movementData.currentRightFuel += Time.deltaTime * refuellingSpeed;
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().StopSound("audio_refueling");
                        refuelling = false;
                    }
                }
                else
                {
                    FindObjectOfType<AudioManager>().StopSound("audio_refueling");
                    refuelling = false;
                }
            }
        }
        else if (gameData.extraFuel > 0)
        {
            if (inputData.refuelInput != 0)
            {
                if (inputData.mainTank != 0 && movementData.currentMainFuel < movementData.mainTankMaxFuel)
                {
                    gameData.extraFuel -= Time.deltaTime * refuellingSpeed;
                    movementData.currentMainFuel += Time.deltaTime * refuellingSpeed;
                    Refuel();
                }
                else if (inputData.leftTank != 0 && movementData.currentLeftFuel < movementData.sideTanksMaxFuel)
                {
                    gameData.extraFuel -= Time.deltaTime * refuellingSpeed;
                    movementData.currentLeftFuel += Time.deltaTime * refuellingSpeed;
                    Refuel();
                }
                else if (inputData.rightTank != 0 && movementData.currentRightFuel < movementData.sideTanksMaxFuel)
                {
                    gameData.extraFuel -= Time.deltaTime * refuellingSpeed;
                    movementData.currentRightFuel += Time.deltaTime * refuellingSpeed;
                    Refuel();
                }
                else
                {
                    FindObjectOfType<AudioManager>().StopSound("audio_refueling");
                    refuelling = false;
                }
            }
            else
            {
                FindObjectOfType<AudioManager>().StopSound("audio_refueling");
                refuelling = false;
            }

        }
        else
        {
            FindObjectOfType<AudioManager>().StopSound("audio_refueling");
            refuelling = false;
        }
    }

    void Refuel()
    {
        if (!refuelling)
        {
            refuelling = true;
            eRefueling.Raise();
        }
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
