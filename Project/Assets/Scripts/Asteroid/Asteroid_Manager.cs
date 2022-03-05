using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Manager : MonoBehaviour
{
    public static List<GameObject> asteroids = new List<GameObject>();
    [SerializeField] GameObject asteroid_go;
    float time_before_next_asteroid;

    int i = 0;

    void Update()
    {
        time_before_next_asteroid -= Time.deltaTime;
        if (time_before_next_asteroid <= 0) SpawnAsteroid(GameManager.notes[i]);
    }


    void SpawnAsteroid(Note note) {
        GameObject new_asteroid = Instantiate(asteroid_go);
        Transform new_asteroid_transform = new_asteroid.transform;

        asteroids.Add(new_asteroid);

        new_asteroid_transform.SetParent(this.transform);
        new_asteroid_transform.name = note.Name + " - Asteroid " + asteroids.Count;
        new_asteroid_transform.position = new Vector3(transform.position.x, note.Position_Y, transform.position.z);
        
        time_before_next_asteroid = note.Duration;

        i++;
        if (i > GameManager.notes.Count - 1) i = 0;
    }
}