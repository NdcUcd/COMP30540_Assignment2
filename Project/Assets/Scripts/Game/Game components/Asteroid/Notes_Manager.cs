using System.Collections.Generic;
using UnityEngine;

public class Notes_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> asteroid_go = new List<GameObject>();
    float time_before_next_note;
    GameManager gameManager;

    void Start()
    {
        time_before_next_note = Level.Time_Before_Next_Note;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        time_before_next_note -= Time.deltaTime;

        if (time_before_next_note <= 0) Call_Next_Note();
    }

    int previouNoteIndex;

    void Call_Next_Note()
    {
        int node_index = Get_New_Note();

        SpawnAsteroid(GameManager.notes[node_index]);
        time_before_next_note = Level.Time_Before_Next_Note;

        previouNoteIndex = node_index;

        if (GameManager.infiniteMode) return;

        if (GameManager.AskAgain)
        {
            if (Level.Total_Notes <= 0 && gameManager.Succes_Rate >= 90)
                gameManager.DisplayMenu(false);
            else
                Level.Total_Notes--;
        }
    }

    public void ResetTotalNotes() { Level.Total_Notes = Level.InitialNbOfNotes; }

    //Determine which note is next to be spawned
    int Get_New_Note()
    {
        int noteIndex = 0;

        do
            noteIndex = Random.Range(0, Level.Tessitura);
        while (Mathf.Abs(previouNoteIndex - noteIndex) > Level.Max_Interval - 1
            || previouNoteIndex == noteIndex);  //Because I don't want the same notes 2 times in a row
        
        previouNoteIndex = noteIndex;

        return noteIndex;
    }

    public void SpawnAsteroid(Note note)
    {
        GameObject new_asteroid = Instantiate(asteroid_go[Random.Range(0, asteroid_go.Count)]);
        Asteroid asteroidScript = new_asteroid.AddComponent<Asteroid>();
        asteroidScript.Note = note.Name;

        Transform new_asteroid_transform = new_asteroid.transform;

        new_asteroid_transform.SetParent(this.transform);
        new_asteroid_transform.name = note.Name + " - Asteroid " + new_asteroid_transform.GetSiblingIndex();
        new_asteroid_transform.position = new Vector3(transform.position.x, note.Position_Y, transform.position.z);
    }

    public void DestroyAllAsteroids()
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
}