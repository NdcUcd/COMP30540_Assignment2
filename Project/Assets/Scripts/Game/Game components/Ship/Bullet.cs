using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 position;
    GameManager.Notes note;

    public void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        float newX = transform.position.x + speed * Time.deltaTime;
        transform.position = new Vector3(newX, position.y, position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collision_go = collision.gameObject;

        if (collision_go.layer == 6 && note == collision.transform.GetComponent<Asteroid>().Note) //Collision with asteroid
            Collision_With_Asteroid(collision_go); 
        else if (collision_go.layer == 8)                                                         //Collision with right border limit
            Collision_With_Right_Border();              
    }
    public GameManager.Notes Note
    {
        get { return note; }
        set { note = value; }
    }

    void Collision_With_Asteroid(GameObject asteroid_go)
    {
        GameManager.GoodNote();
        Destroy(asteroid_go.gameObject);
        Destroy(gameObject);
    }

    void Collision_With_Right_Border()
    {
        GameManager.False_Note();
        Destroy(gameObject);
    }
}
