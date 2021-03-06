using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera1;
    public CinemachineVirtualCamera vCamera2;

    public float closestPossible;

    public float furthestPossible;

    public float zoomModifier;
    public float speedUp;

    public InputData inputData;
    public StatsData statsData;

    public GameData gameData;

    public GameObject rocket;

    ActionMaps inputActions;

    //bool coroutineRunning;



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

    public void ShowReturn()
    {
        vCamera2.gameObject.SetActive(true);
        StartCoroutine(ShowFirstPlanet());
    }

    IEnumerator ShowFirstPlanet()
    {
        yield return new WaitForSeconds(5);
        vCamera2.gameObject.SetActive(false);
    }

    private void ZoomIn()
    {
        if (vCamera1.m_Lens.OrthographicSize > closestPossible)
        {
            vCamera1.m_Lens.OrthographicSize -= Time.deltaTime * (zoomModifier + speedUp);
        }
    }

    private void ZoomOut()
    {
        if (vCamera1.m_Lens.OrthographicSize < furthestPossible)
        {
            vCamera1.m_Lens.OrthographicSize += Time.deltaTime * (zoomModifier + speedUp);
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
