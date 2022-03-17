using System.Collections.Generic;
using UnityEngine;

public class Notes_Manager : MonoBehaviour
{
    [SerializeField] GameObject asteroid_go;
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

    int previous_node_index;

    void Call_Next_Note()
    {
        int node_index = Get_New_Note();

        SpawnAsteroid(GameManager.notes[node_index]);
        time_before_next_note = Level.Time_Before_Next_Note;

        previous_node_index = node_index;

        if (GameManager.infiniteMode) return;

        if (GameManager.AskAgain)
        {
            if (Level.Total_Notes <= 0 && gameManager.Succes_Rate >= 90)
                gameManager.DisplayMenu(false);
            else
                Level.Total_Notes--;
        }
    }

    public void ResetTotalNotes() { Level.Total_Notes = 5; }

    //Determine which note is next to be spawned
    int Get_New_Note()
    {
        int node_index = 0;

        do
            node_index = Random.Range(0, Level.Tessiturat);
        while (Mathf.Abs(previous_node_index - node_index) > Level.Max_Interval 
            || previous_node_index == node_index);  //Because I don't want the same notes 2 times in a row

        return node_index;
    }

    public void SpawnAsteroid(Note note)
    {
        GameObject new_asteroid = Instantiate(asteroid_go);
        new_asteroid.GetComponent<Asteroid>().Note = note.Name;

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

    //void Next_Level()
    //{
    //    Level.current_level(Level.Level_Number + 1);
    //    UpdateLevel_UI.Update_Level();
    //}
}