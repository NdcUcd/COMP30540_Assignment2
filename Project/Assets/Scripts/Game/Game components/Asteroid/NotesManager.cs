using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    [SerializeField] List<GameObject> asteroid_go = new List<GameObject>();
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();

    public static List<AudioClip> _audioClips = new List<AudioClip>();

    [SerializeField] GameObject line;
    float time_before_next_note = 2;
    GameManager gameManager;

    void Start()
    {
        //time_before_next_note = Level.Time_Before_Next_Note;
        gameManager = FindObjectOfType<GameManager>();
        _audioClips = audioClips;
    }

    void Update()
    {
        time_before_next_note -= Time.deltaTime;

        if (time_before_next_note <= 0) Call_Next_Note();
    }

    int previouNoteIndex;

    void Call_Next_Note()
    {
        int node_index;

        if (!GameManager.tutorialMode) node_index = Get_New_Note();
        else node_index = GetTutorialNotes();

        SpawnAsteroid(GameManager.notes[node_index]);
        time_before_next_note = Level.Time_Before_Next_Note;

        previouNoteIndex = node_index;

        if (GameManager.infiniteMode) return;

        if (GameManager.AskAgain && (Level.Level_Number < Level.LevelMax))
        {
            if (Level.Total_Notes <= 0 && gameManager.Succes_Rate >= 90)
                gameManager.DisplayMenu(false);
            else
                Level.Total_Notes--;
        }
    }

    int[] tutorialNotes = new int[] { 0, 2, 4, 7, 9, 4, 7, 9,
                                     // 1, 3, 5, 8, 10, 5, 8, 10,
                                      0, 1, 5, 8, 10, 5, 8, 10,
                                      //1, 2, 6, 9, 11, 6, 9, 11,
                                      1, 3, 4, 8, 10, 4, 8, 10,
                                     // 2, 4, 5, 9, 11, 5, 9, 11,
                                      0, 2, 4, 7, 9, 4, 7, 9//,
                                    //  1, 3, 5, 8, 10, 5, 8, 10
                                    };

    int currentTutorialNoteIndex = 0;
    private int GetTutorialNotes()
    {
        int note = tutorialNotes[currentTutorialNoteIndex]-1;
        currentTutorialNoteIndex++;
        Debug.Log(GameManager.notes[note].Name.ToString());
        Note notePositionToMoveTo = GameManager.notes[note];
        FindObjectOfType<AvatarController>().Move(notePositionToMoveTo);
        return note;
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
        int r = Random.Range(0, asteroid_go.Count);
        GameObject new_asteroid = Instantiate(asteroid_go[r]);
        Asteroid asteroidScript = new_asteroid.AddComponent<Asteroid>();
        asteroidScript.line = this.line;
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