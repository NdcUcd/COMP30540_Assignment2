using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_movement : MonoBehaviour
{
    Vector3 position;
    float speed;

    private void Start()
    {
        position = transform.position;
        speed = Level.Speed;
    }

    void Update()
    {
        float newX = transform.position.x - speed * Time.deltaTime;
        transform.position = new Vector3(newX, position.y, position.z);
    }
}
