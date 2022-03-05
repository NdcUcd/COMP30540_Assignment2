using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Note> notes = new List<Note>();

    public static KeyCode[] keys = {  KeyCode.A , KeyCode.S, KeyCode.D, KeyCode.F,
                        KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K,
                        KeyCode.L, KeyCode.Semicolon, KeyCode.BackQuote };

    public static Ship ship;

    void Start()
    {
        ship = FindObjectOfType<Ship>();

        for (int i = 0; i < Enum.GetNames(typeof(Notes)).Length; i++)
            notes.Add(new Note((Notes)i));
    }

    void OnGUI()
    {
        Event e = Event.current;

        foreach (KeyCode key in keys)
        {
            if (e.isKey && e.keyCode == key)
            {
                ship.Move(key);
            }
        }
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
