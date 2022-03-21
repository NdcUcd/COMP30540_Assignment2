using UnityEngine;

public class Level
{
    static int initialNbOfNotes = 5, level_number, tessitura, max_interval, total_nb_of_notes;
    static float speed, time_before_next_note;
    static GameManager.Key key;

    public Level() { current_level(0); }
    public Level(int level) { current_level(level); }

    public static void current_level(int a_level_number)
    {
        level_number = a_level_number;

        switch (level_number)
        {
            case 1:
                tessitura = 3;
                max_interval = 2;
                speed = 5;
                time_before_next_note = .5f;
                total_nb_of_notes = 5;
                break;
            case 2:
                tessitura = 4;
                max_interval = 3;
                speed = 5;
                time_before_next_note = 1f;
                total_nb_of_notes = 5;
                break;
            //case 3:
            //    break;
            //case 4:
            //    break;
            default:
                if (!GameManager.infiniteMode)
                {
                    tessitura = 7;
                    max_interval = 4;
                    speed = 5;
                    time_before_next_note = .5f;
                    total_nb_of_notes = 15;
                    //Debug.Log(tessiturat + " " + max_interval + " " + speed + " " + time_before_next_note + " " + total_nb_of_notes);
                    //Debug.Log("Default");
                }
                break;
        }
    }

    public static int InitialNbOfNotes
    {
        get { return initialNbOfNotes; }
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

    public static int Tessitura
    {
        get { return tessitura; }
        set { tessitura = value; }
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

    public static float Time_Before_Next_Note
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
