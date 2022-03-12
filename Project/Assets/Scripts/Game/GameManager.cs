using MidiJack;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Note> notes = new List<Note>();

    public static KeyCode[] keys = {  KeyCode.A , KeyCode.S, KeyCode.D, KeyCode.F,
                        KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K,
                        KeyCode.L, KeyCode.Semicolon, KeyCode.BackQuote };

    static int[] keyboard_note_number = { 48, 50, 52, 53, 55, 57, 59, 60, 62, 64, 65, 67, 69, 71, 72 };

    public static Ship ship;
    static int succes_rate;
    static float total_notes = 0, good_notes = 0;

    void Start()
    {
        ship = FindObjectOfType<Ship>();

        for (int i = 0; i < Enum.GetNames(typeof(Notes)).Length; i++)
            notes.Add(new Note((Notes)i));

        Update_Score();
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

    void OnGUI()
    {
        Event e = Event.current;

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

    public int Succes_Rate
    {
        get { return succes_rate; }
        set { succes_rate = value; }
    }

    public static void GoodNote()
    {
        good_notes++;
        total_notes++;
        Update_Score();
    }

    public static void LoseLife()
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
