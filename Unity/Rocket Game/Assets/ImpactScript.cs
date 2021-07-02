using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    public GameEvent eImpact;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        eImpact.Raise();
    }
}
