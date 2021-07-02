using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPathScript : MonoBehaviour
{
    public string meteorType;
    public Rigidbody2D rb;

    public Transform[] points;
    //public Transform pointB;
    //public Transform pointC;
    //public Transform pointD;

    public bool reachedA;
    public bool reachedB;
    
    public float moveSpeed;

    public Transform[] routes;
    int nextRoute;
    float tParam;
    Vector2 position;
    bool coroutineRunning;

    
    // Start is called before the first frame update
    void Start()
    {
        if (meteorType == "A to B")
        {
            int starting = Random.Range(0, 2);
            if (starting == 0)
            {
                reachedA = true;
            }
            else
            {
                reachedB = true;
            }
        }
        else if (meteorType == "Curve")
        {
            nextRoute = 0;
            tParam = 0;
            coroutineRunning = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (meteorType == "A to B")
        {
            if (Vector2.Distance(transform.position, points[0].position) < 1)
            {
                reachedA = true;
            }

            if (reachedA)
            {
                reachedB = false;
            }

            if (Vector2.Distance(transform.position, points[1].position) < 1)
            {
                reachedB = true;
            }

            if (reachedB)
            {
                reachedA = false;
            }

            if (reachedA)
            {
                Vector2 direction = points[1].position - transform.position;
                direction = direction.normalized;
                //Debug.Log(direction.ToString());
                Vector2 newPosition = new Vector2(transform.position.x + (direction.x * moveSpeed), transform.position.y + (direction.y * moveSpeed));
                rb.MovePosition(newPosition);
            }

            if (reachedB)
            {
                Vector2 direction = points[0].position - transform.position;
                direction = direction.normalized;
                //Debug.Log(direction.ToString());
                Vector2 newPosition = new Vector2(transform.position.x + (direction.x * moveSpeed), transform.position.y + (direction.y * moveSpeed));
                rb.MovePosition(newPosition);
            }
        }
        else if (meteorType == "Curve")
        {
            if (!coroutineRunning)
            {
                StartCoroutine(FollowCurve(nextRoute));
            }
        }
    }

    IEnumerator FollowCurve(int curveNumber)
    {
        coroutineRunning = true;

        Vector2 p0 = routes[curveNumber].GetChild(0).position;
        Vector2 p1 = routes[curveNumber].GetChild(1).position;
        Vector2 p2 = routes[curveNumber].GetChild(2).position;
        Vector2 p3 = routes[curveNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * moveSpeed;

            position = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            rb.MovePosition(position);
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        nextRoute++;

        if (nextRoute > routes.Length - 1)
        {
            nextRoute = 0;
        }

        coroutineRunning = false;
    }



}
