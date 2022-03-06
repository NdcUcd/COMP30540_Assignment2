using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Vector3 position;
    float speed;
    GameManager.Notes note;

    public void Start()
    {
        position = transform.position;
        speed = Level.Speed;
        GameManager.total_notes++;
    }

    void Update()
    {
        float newX = transform.position.x - speed * Time.deltaTime;
        transform.position = new Vector3(newX, position.y, position.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8) Destroy(gameObject);
        else if (collision.gameObject.layer == 9) Collision_Base();
    }

    public GameManager.Notes Note
    {
        get { return note; }
        set { note = value; }
    }

    void Collision_Base()
    {
        GameManager.LoseLife();
        Destroy(gameObject);
    }
}
