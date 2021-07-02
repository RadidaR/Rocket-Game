using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPosition : MonoBehaviour
{
    public LayerMask damageLayer;

    public GameObject indicator;
    public GameObject indicatorPrefab;

    Transform target;
    Transform rocket;

    public Renderer _renderer;
    public LayerMask indicatorLayer;

    bool coroutineRunning;



    private void Awake()
    {
        target = FindObjectOfType<Camera>().gameObject.transform;
        rocket = FindObjectOfType<RocketMovementScript>().gameObject.GetComponentInChildren<Rigidbody2D>().gameObject.transform;

        if (gameObject.tag == "Fuel")
        {

        }
        else if (gameObject.tag == "Life")
        {

        }

        if (Physics2D.OverlapCircle(transform.position, 2, damageLayer))
        {
            CheckForObstacles();
        }
    }


    private void FixedUpdate()
    {
        if (!_renderer.isVisible)
        {
            if (!coroutineRunning)
            {
                StartCoroutine(ShowIndicator());
            }
            
        }
        else
        {
            if (indicator != null)
            {
                if (indicator.activeInHierarchy)
                {
                    indicator.SetActive(false);
                }
            }
        }
    }

    IEnumerator ShowIndicator()
    {
        coroutineRunning = true;
        if (indicator == null)
        {
            indicator = Instantiate(indicatorPrefab, FindObjectOfType<CanvasScript>().gameObject.GetComponentInChildren<Canvas>().gameObject.transform, true);
            indicator.transform.position = indicator.transform.position.SetValues(z: -1);
        }

        while (Vector2.Distance(transform.position, rocket.position) < 175)
        {

            if (!indicator.activeInHierarchy)
            {
                indicator.SetActive(true);
            }

            Vector2 directionToTarget = target.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, directionToTarget, Vector2.Distance(transform.position, target.position), indicatorLayer);


            if (ray.collider != null)
            {
                indicator.transform.position = ray.point;
            }

            Vector2 pointingDirection = target.position;
            pointingDirection = pointingDirection.Direction(transform.position);

            float angle = Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg - 90f;

            indicator.GetComponent<Rigidbody2D>().rotation = angle;
            yield return new WaitForFixedUpdate();

            if (Vector2.Distance(transform.position, rocket.position) >= 175 || _renderer.isVisible)
            {
                indicator.SetActive(false);
                coroutineRunning = false;
                break;
            }
        }
    }


    void CheckForObstacles()
    {
        Vector2 obstaclePos = Physics2D.OverlapCircle(transform.position, 2, damageLayer).transform.position;
        Vector2 pos = transform.position;

        Vector2 direction = pos.Direction(obstaclePos);

        pos -= direction * 5;
        transform.position = pos;

    }
}
