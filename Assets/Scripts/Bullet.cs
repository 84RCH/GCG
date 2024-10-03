using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        GameObject goal = GameObject.Find("Goal");
        Vector3 goalPosition = goal.transform.position;
        //goalPosition.z = -1;

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if ((transform.position.x == goalPosition.x)
            && (transform.position.y == goalPosition.y))
        {
            Destroy(this.gameObject);
        }
    }

}
