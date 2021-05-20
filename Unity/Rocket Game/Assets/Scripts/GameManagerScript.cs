using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public StatsData statsData;
    public GameData gameData;
    public MovementData movementData;

    public GameObject rocketBody;
    public Rigidbody2D rocketRB;

    public PlanetSpawnerScript planetSpawner;
    public RocketCollisionScript rocketCollision;

    public GameObject lastVisitedPlanet;
    public GameObject nextPlanet;

    public Transform boundaries;

    private void Update()
    {
        //if (statsData.nearPlatform)
        //{
        //    if (rocketRB.velocity == Vector2.zero && rocketRB.angularVelocity == 0)
        //    {
        //        //Vector2 direction =  (rocketRB.gameObject.transform.localPosition.x, rocketRB.gameObject.transform.localPosition.y) - rocketRB.gameObject.transform.localPosition))
        //        RaycastHit2D ray = Physics2D.Raycast(rocketRB.gameObject.transform.position,new Vector3(rocketRB.gameObject.transform.localPosition.x, rocketRB.gameObject.transform.localPosition.y - 5) - rocketRB.gameObject.transform.position , 3, 7);
        //        if (ray)
        //        {
        //            gameData.lastPlatformPosition = rocketBody.transform.position;
        //            gameData.lastPlatformRotation = rocketBody.transform.rotation;

        //            gameData.mainFuel = movementData.currentMainFuel;
        //            gameData.leftFuel = movementData.currentLeftFuel;
        //            gameData.rightFuel = movementData.currentRightFuel;
        //            Debug.Log("hits");
        //        }
        //        else
        //        {
        //            Debug.Log("doesn't hit");
        //        }


        //    }
        //}

        lastVisitedPlanet = rocketCollision.currentPlanet;
        nextPlanet = planetSpawner.newPlanet;

        if (lastVisitedPlanet != null && nextPlanet != null)
        { 
            boundaries.position = new Vector2((lastVisitedPlanet.transform.position.x + nextPlanet.transform.position.x) / 2, 0);
        }
    }


}
