using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Vector3 position;
    float speed;
    GameManager.Notes note;
    public GameObject line;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public bool audioHasPlayed = false;

    public void Start()
    {
        position = transform.position;
        speed = Level.Speed;

        int noteIndex = (int) note;

        if (noteIndex <= (int) GameManager.Notes.C3)
        {
            bool lineHasToBeInTheMidle = (( (int) GameManager.Notes.C3 - noteIndex) % 2) == 0;
            AddLine(lineHasToBeInTheMidle);
        }


        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = NotesManager._audioClips[(int)note];
    }

    void Update()
    {
        float newX = transform.position.x - speed * Time.deltaTime;
        transform.position = new Vector3(newX, position.y, position.z);

        if (audioHasPlayed && !audioSource.isPlaying) Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Collision_Base();
        }
        else if (collision.gameObject.layer == 9)   //Collide with base
        {
            Debug.Log("collide with layer 9: " + collision.gameObject.layer.ToString());
            //Collision_Base();
        }
    }

    void AddLine(bool middleLine)
    {
        int posY = 0;
        if (!middleLine) posY = 140;

        Transform lineTransform = Instantiate(line).transform;

        lineTransform.SetParent(this.gameObject.transform);
        lineTransform.localPosition = new Vector3(0, posY, -200);
        lineTransform.localScale = new Vector3(20, 200, 30);
    }

    public GameManager.Notes Note
    {
        get { return note; }
        set { note = value; }
    }

    void Collision_Base()
    {
        GameManager.Error();
        Destroy(gameObject);
    }

    public void DestroyAsteroidOnGoodNote()
    {
        transform.SetParent(GameObject.Find("Destroyed asteroids").transform);
        transform.GetComponent<MeshRenderer>().enabled = false;
        transform.GetComponent<SphereCollider>().enabled = false;

        //When a line is attached to the asteroid (for notes below C3)
        if (transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
    }
}
