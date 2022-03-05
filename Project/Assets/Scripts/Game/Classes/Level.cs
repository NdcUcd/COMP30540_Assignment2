using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level
{
    static int level_number, tessiturat, max_interval;
    static float speed = 5;
    static GameManager.Key key;

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
    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public static GameManager.Key Key
    {
        get { return key; }
        set { key = value; }
    }
}
