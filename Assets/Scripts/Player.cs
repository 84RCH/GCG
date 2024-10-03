using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;//bullet PreFab System
    public LineRenderer lineRenderer;//draw Line

    public int lineSegmentCount = 30;//segment
    public float lineThickness = 0.1f;//thickness

    public float fireRate = 0.5f; // rate
    private float nextFireTime = 0f; // next FireRate

    void Start()
    {
        // get SpriteRenderer Component
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.Translate(0, 0, -1);

        // set LineRenderer
        lineRenderer.startWidth = lineThickness;
        lineRenderer.endWidth = lineThickness;
        lineRenderer.positionCount = lineSegmentCount;
    }
    void Update()
    {
        MovePlayer();

        //mouse Left Button
        if (Input.GetMouseButton(0)&&Time.time>=nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time+fireRate;//setting Next FireRate
        }

        //draw Trail
        DrawTrail();
    }

    void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
        }
    }

    void Shoot()
    {
        // get mouse pos
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // mouse direction
        Vector3 direction = (mousePosition - transform.position).normalized;

        // generate bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.up = direction;
    }

    void DrawTrail()
    {
        // et mouse pos
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // mouse direction
        Vector3 direction = (mousePosition - transform.position).normalized;

        //distance
        float distance = Vector3.Distance(transform.position, mousePosition);

        // trail Point
        for (int i = 0; i < lineSegmentCount; i++)
        {
            float t = i / (float)(lineSegmentCount - 1);
            Vector3 point = (Vector3)transform.position + direction * t * distance;
            lineRenderer.SetPosition(i, point);
        }
    }
}
