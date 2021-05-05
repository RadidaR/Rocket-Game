using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RocketMovementScript : MonoBehaviour
{
    ActionMaps inputActions;

    public float mainThrusterInput;
    public float mainThrusterForce;

    public float leftThrusterInput;
    public float leftThrusterForce;

    public float rightThrusterInput;
    public float rightThrusterForce;

    public float leftBreakInput;
    public float leftBreakForce;

    public float rightBreakInput;
    public float rightBreakForce;


    public Rigidbody2D mainThrusterRB;
    public Rigidbody2D leftThrusterRB;
    public Rigidbody2D rightThrusterRB;
    public Rigidbody2D leftBreakRB;
    public Rigidbody2D rightBreakRB;

    private void OnValidate()
    {
        if (gameObject.activeInHierarchy)
        {
            mainThrusterRB = gameObject.transform.Find("Main Thruster").gameObject.GetComponent<Rigidbody2D>();
            leftThrusterRB = gameObject.transform.Find("Left Thruster").gameObject.GetComponent<Rigidbody2D>();
            rightThrusterRB = gameObject.transform.Find("Right Thruster").gameObject.GetComponent<Rigidbody2D>();
            leftBreakRB = gameObject.transform.Find("Left Break").gameObject.GetComponent<Rigidbody2D>();
            rightBreakRB = gameObject.transform.Find("Right Break").gameObject.GetComponent<Rigidbody2D>();
        }
    }
    void Awake()
    {
        inputActions = new ActionMaps();

        inputActions.Gameplay.MainThruster.performed += ctx => mainThrusterInput = inputActions.Gameplay.MainThruster.ReadValue<float>();
        inputActions.Gameplay.MainThruster.canceled += ctx => mainThrusterInput = inputActions.Gameplay.MainThruster.ReadValue<float>();

        inputActions.Gameplay.LeftThruster.performed += ctx => leftThrusterInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();
        inputActions.Gameplay.LeftThruster.canceled += ctx => leftThrusterInput = inputActions.Gameplay.LeftThruster.ReadValue<float>();

        inputActions.Gameplay.RightThruster.performed += ctx => rightThrusterInput = inputActions.Gameplay.RightThruster.ReadValue<float>();
        inputActions.Gameplay.RightThruster.canceled += ctx => rightThrusterInput = inputActions.Gameplay.RightThruster.ReadValue<float>();

        inputActions.Gameplay.LeftBreak.performed += ctx => leftBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>();
        inputActions.Gameplay.LeftBreak.canceled += ctx => leftBreakInput = inputActions.Gameplay.LeftBreak.ReadValue<float>();

        inputActions.Gameplay.RightBreak.performed += ctx => rightBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>();
        inputActions.Gameplay.RightBreak.canceled += ctx => rightBreakInput = inputActions.Gameplay.RightBreak.ReadValue<float>();
    }

    void FixedUpdate()
    {
        if (mainThrusterInput != 0 || leftThrusterInput != 0 || rightThrusterInput != 0 || leftBreakInput != 0 || rightBreakInput != 0)
        {
            Move();
        }
    }

    void Move()
    {
        mainThrusterRB.AddRelativeForce(Vector2.up * mainThrusterForce * mainThrusterInput);
        leftThrusterRB.AddRelativeForce(Vector2.up * leftThrusterForce * leftThrusterInput);
        rightThrusterRB.AddRelativeForce(Vector2.up * rightThrusterForce * rightThrusterInput);
        leftBreakRB.AddRelativeForce(Vector2.down * leftBreakForce * leftBreakInput);
        rightBreakRB.AddRelativeForce(Vector2.down * rightBreakForce * rightBreakInput);
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
