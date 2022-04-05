using System;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    Vector3 original_position;
    static bool canMove = true;

    void Start() { original_position = transform.position; }

    public void Move(KeyCode key)
    {
        Note note_played = GameManager.notes[Array.IndexOf(GameManager.keys, key)];

        Move(note_played);      
    }

    public void Move(Note note)
    {
        transform.position = new Vector3(original_position.x,
                                      note.Position_Y,
                                      original_position.z);

        Shoot(note.Name);
    }

    public static bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    void Shoot(GameManager.Notes note)
    {
        GameObject bullet_go = Instantiate(bullet);
        bullet_go.GetComponent<Bullet>().Note = note;
        Transform bulletTransform = bullet_go.transform;
        bulletTransform.SetParent(this.transform);
        bulletTransform.position = transform.position;
        bulletTransform.name = "Bullet " + transform.childCount.ToString();

        //Debug.Log("shoots " + note.ToString());
    }

    public void DestroyAllBullets()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
