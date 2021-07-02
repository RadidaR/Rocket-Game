using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    int rotationDirection;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 2);
        
        if (random == 0)
        {
            rotationDirection = 1;
        }
        else
        {
            rotationDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0, rotationDirection) * Time.deltaTime * rotationSpeed);
    }
}
