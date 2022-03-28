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

        if (collision_go.layer == 6 && note == collision.transform.GetComponent<Asteroid>().Note)
        {
            if (collision.gameObject.transform.GetSiblingIndex() == 0) //We only want to destroy an asteroid if it's the one closer to the base
                Collision_With_Asteroid(collision_go);
            else
                CollisionWithWrongObject();
        }
        else if (collision_go.layer == 8)
        {                                                        //Collision with right border limit
            CollisionWithWrongObject();
        }
    }
    public GameManager.Notes Note
    {
        get { return note; }
        set { note = value; }
    }

    void Collision_With_Asteroid(GameObject asteroid_go)
    {
        GameManager.GoodNote(asteroid_go);
        asteroid_go.GetComponent<Asteroid>().DestroyAsteroidOnGoodNote();
        Destroy(gameObject);
    }

    void CollisionWithWrongObject()
    {
        GameManager.Error();
        Destroy(gameObject);
    }
}