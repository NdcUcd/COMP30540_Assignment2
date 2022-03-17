using System;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    Vector3 original_position;

    void Start() { original_position = transform.position; }

    public void Move(KeyCode key)
    {
        Note note_played = GameManager.notes[Array.IndexOf(GameManager.keys, key)];

        transform.position = new Vector3(original_position.x,
                                        note_played.Position_Y,
                                        original_position.z);

        Shoot(note_played.Name);
    }

    void Shoot(GameManager.Notes note)
    {
        GameObject bullet_go = Instantiate(bullet);
        bullet_go.GetComponent<Bullet>().Note = note;
        Transform bulletTransform = bullet_go.transform;
        bulletTransform.SetParent(this.transform);
        bulletTransform.position = transform.position;
        bulletTransform.name = "Bullet " + transform.childCount.ToString();
    }

    public void DestroyAllBullets()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
