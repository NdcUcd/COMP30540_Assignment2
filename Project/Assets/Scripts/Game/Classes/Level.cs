using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    static int level_number, tessiturat, max_interval, total_nb_of_notes;
    static float speed, time_before_next_note;
    static GameManager.Key key;

    public Level() { current_level(1); }

    public static void current_level(int a_level_number)
    {
        level_number = a_level_number;

        switch (level_number)
        {
            case 1:
                tessiturat = 3;
                max_interval = 1;
                speed = 5;
                time_before_next_note = .5f;
                total_nb_of_notes = 10;
                break;
            case 2:
                tessiturat = 4;
                max_interval = 3;
                speed = 5;
                time_before_next_note = 1f;
                total_nb_of_notes = 15;
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    public static int Level_Number
    {
        get { return level_number; }
        set { level_number = value; }
    }

    //Max interval between 2 consecutive notes
    public static int Max_Interval
    {
        get { return max_interval; }
        set { max_interval = value; }
    }

    public static int Tessiturat
    {
        get { return tessiturat; }
        set { tessiturat = value; }
    }
    public static int Total_Notes
    {
        get { return total_nb_of_notes; }
        set { total_nb_of_notes = value; }
    }

    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public static float Time_Before_Next_Asteroid
    {
        get { return time_before_next_note; }
        set { time_before_next_note = value; }
    }

    public static GameManager.Key Key
    {
        get { return key; }
        set { key = value; }
    }
}
