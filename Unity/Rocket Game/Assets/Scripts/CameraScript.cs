using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;

    public float closestPossible;

    public float furthestPossible;

    public float zoomModifier;
    public float speedUp;

    public InputData inputData;
    public StatsData statsData;

    public GameData gameData;

    public GameObject rocket;

    ActionMaps inputActions;

    bool coroutineRunning;



    private void Awake()
    {
        inputActions = new ActionMaps();

        inputActions.Gameplay.CameraControl.performed += ctx => inputData.cameraControl = inputActions.Gameplay.CameraControl.ReadValue<float>();
        inputActions.Gameplay.CameraControl.canceled += ctx => inputData.cameraControl = inputActions.Gameplay.CameraControl.ReadValue<float>();
        inputActions.Gameplay.CameraControl.canceled += ctx => speedUp = 0;

        inputActions.Gameplay.ZoomIn.performed += ctx => inputData.zoomIn = inputActions.Gameplay.ZoomIn.ReadValue<float>();
        inputActions.Gameplay.ZoomIn.canceled += ctx => inputData.zoomIn = inputActions.Gameplay.ZoomIn.ReadValue<float>();

        inputActions.Gameplay.ZoomOut.performed += ctx => inputData.zoomOut = inputActions.Gameplay.ZoomOut.ReadValue<float>();
        inputActions.Gameplay.ZoomOut.canceled += ctx => inputData.zoomOut = inputActions.Gameplay.ZoomOut.ReadValue<float>();
    }
    private void Update()
    {
        if (inputData.cameraControl != 0)
        {
            if (inputData.zoomIn != 0)
            {
                speedUp += zoomModifier * Time.deltaTime;
                ZoomIn();
            }
            else if (inputData.zoomOut != 0)
            {
                speedUp += zoomModifier * Time.deltaTime;
                ZoomOut();
            }
        }

    }


    private void ZoomIn()
    {
        if (vCamera.m_Lens.OrthographicSize > closestPossible)
        {
            vCamera.m_Lens.OrthographicSize -= Time.deltaTime * (zoomModifier + speedUp);
        }
    }

    private void ZoomOut()
    {
        if (vCamera.m_Lens.OrthographicSize < furthestPossible)
        {
            vCamera.m_Lens.OrthographicSize += Time.deltaTime * (zoomModifier + speedUp);
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
