using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    public GameObject offScreenIndicator;
    public Transform target;

    public LayerMask indicatorLayer;

    public Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        //_renderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (!_renderer.isVisible)
        {
            if (!offScreenIndicator.activeInHierarchy)
            {
                offScreenIndicator.SetActive(true);
            }

            Vector2 directionToTarget = target.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, directionToTarget, Vector2.Distance(transform.position, target.position), indicatorLayer);


            if (ray.collider != null)
            {
                //Debug.Log("hit");
                offScreenIndicator.transform.position = ray.point;
            }

            Vector2 pointingDirection = target.position;
            pointingDirection = pointingDirection.Direction(transform.position);

            float angle = Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg - 90f;

            offScreenIndicator.GetComponent<Rigidbody2D>().rotation = angle;
        }
        else
        {
            if (offScreenIndicator.activeInHierarchy)
            {
                offScreenIndicator.SetActive(false);
            }
        } 
    }
}
