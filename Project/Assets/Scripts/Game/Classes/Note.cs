using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    GameManager.Notes name;
    float position_y;
    KeyCode key_associated;

    //time before next note spawns
    float duration = 2f;

    public Note(GameManager.Notes name) {
        this.name = name;

        //Get position at which notes are
        position_y = GameObject.Find("Notes").transform.GetChild((int)name).transform.position.y;

        key_associated = GameManager.keys[(int)name];
    }

    public GameManager.Notes Name {
        get { return this.name; }
        set { this.name = value; }
    }

    public float Position_Y
    {
        get { return this.position_y; }
        set { this.position_y = value; }
    }
    public float Duration
    {
        get { return this.duration; }
        set { this.duration = value; }
    }

    public KeyCode Key_Associated
    {
        get { return key_associated; }
        set { key_associated = value; }
    }
}
