using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPiecesScript : MonoBehaviour
{
    public int damagingLayer;
    public int stuckPieceLayer;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == damagingLayer)
        {
            gameObject.layer = stuckPieceLayer;
            //GetComponent<PolygonCollider2D>().enabled = false;
            //GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }
}
