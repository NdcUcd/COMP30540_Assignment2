using Michsky.UI.Shift;
using MidiJack;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(TutorialManager))]
public class GameManager : MonoBehaviour
{
    public static List<Note> notes = new List<Note>();

    public static KeyCode[] keys = {  KeyCode.A , KeyCode.S, KeyCode.D, KeyCode.F,
                        KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K,
                        KeyCode.L, KeyCode.Semicolon, KeyCode.BackQuote };

    static int[] keyboard_note_number = { 48, 50, 52, 53, 55, 57, 59, 60, 62, 64, 65, 67, 69, 71, 72 };

    public static AvatarController ship;
    static int succes_rate = 0, levelToLoad = 1;
    static float total_notes = 0, good_notes = 0;

    NotesManager asteroid_Manager;
    public static Level level;
    public static bool infiniteMode = false;

    [SerializeField] GameObject menus, canvasAI;
    static bool askAgain = true;
    public static bool tutorialMode = false;

    void Start()
    {
        if (infiniteMode) level = new Level();
        else level = new Level(levelToLoad);

        ship = FindObjectOfType<AvatarController>();

        for (int i = 0; i < Enum.GetNames(typeof(Notes)).Length; i++)
            notes.Add(new Note((Notes)i));

        Update_Score();
        UpdateLevel_UI.Update_Level();

        asteroid_Manager = FindObjectOfType<NotesManager>();

        if (Time.timeScale == 0) Time.timeScale = 1;
        if (!AvatarController.CanMove) AvatarController.CanMove = true;

        if (tutorialMode) EnableTutorialMode();
    }

    void EnableTutorialMode()
    {
        GetComponent<TutorialManager>().enabled = true;
    }

    private void OnEnable()
    {
        succes_rate = 0;
        total_notes = good_notes = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) DisplayMenu(true);
    }

    void OnGUI()
    {
        if (!tutorialMode)
        {
            Event e = Event.current;

            if (AvatarController.CanMove)
            {
                //Inputs from keyboard
                foreach (KeyCode key in keys)
                    if (Input.GetKeyDown(key) && e.isKey && e.keyCode == key)
                    {
                        ship.Move(key);
                        return;
                    }

                //Inputs from MIDI keyboard
                foreach (int key in keyboard_note_number)
                    if (MidiMaster.GetKeyDown(key))
                    {
                        int key_index = Array.IndexOf(keyboard_note_number, key);

                        if (key_index < keys.Length && key_index >= 0)
                            ship.Move(keys[key_index]);

                        return;
                    }
            }
        }

    }

    public static void SetLevelNbToLoad(int nb) { levelToLoad = nb; }

    public void DisplayMenu(bool pause)
    {
        bool menuIsActive = menus.activeSelf;
        menus.SetActive(!menuIsActive);

        if (pause) //Active pause menu
        {
            menus.transform.GetChild(0).gameObject.SetActive(!menuIsActive);
            if (menus.transform.GetChild(1).gameObject.activeInHierarchy) menus.transform.GetChild(1).gameObject.SetActive(false);
        }
        else //Active next level menu
        {
            menus.transform.GetChild(1).gameObject.SetActive(!menuIsActive);
            if (menus.transform.GetChild(0).gameObject.activeInHierarchy) menus.transform.GetChild(0).gameObject.SetActive(false);
            canvasAI.SetActive(!menuIsActive);
        }

        if (!menuIsActive) Time.timeScale = 0;
        else Time.timeScale = 1;

        AvatarController.CanMove = menuIsActive;
    }

    public static void Update_Score()
    {
        if (total_notes == 0)
        {
            UpdateScore.Update_Score(100);
            return;
        }

        succes_rate = (int)(good_notes / total_notes * 100);
        UpdateScore.Update_Score(succes_rate);
    }

    public void NextLevel() { 
        Level.current_level(Level.Level_Number + 1);
        UpdateLevel_UI.Update_Level();
        asteroid_Manager.DestroyAllAsteroids();
        ship.DestroyAllBullets();
        succes_rate = 0;
    }

    public void SetAskAgain()
    {
        askAgain = GameObject.Find("Toggle ask again").GetComponent<SwitchManager>().isOn;
    }

    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public static void SetTutorialMode(bool isInTutoMode)
    {
        tutorialMode = isInTutoMode;
    }

    public int Succes_Rate
    {
        get { return succes_rate; }
        set { succes_rate = value; }
    }

    public int LevelToLoad
    {
        get { return levelToLoad; }
        set { levelToLoad = value; }
    }

    public static bool AskAgain
    {
        get { return askAgain; }
        set { askAgain = value; }
    }

    public static void GoodNote(GameObject asteroid)
    {
        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        asteroidScript.audioSource.Play();
        asteroidScript.audioHasPlayed = true;
        good_notes++;
        total_notes++;
        Update_Score();
    }

    public static void Error()
    {
        total_notes++;
        Update_Score();
    }

    public enum Notes
    {
        C3, D3, E3, F3, G3, A3, B3, C4, D4, E4, F4
    }
    public enum Key
    {
        key_G2, key_F4, key_F3, key_C1, key_C2, key_C3, key_C4, key_C5
    }
}
