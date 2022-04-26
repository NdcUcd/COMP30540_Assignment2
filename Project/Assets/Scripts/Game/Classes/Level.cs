public class Level
{
    static int initialNbOfNotes = 5, level_number, tessitura, max_interval, total_nb_of_notes, maxLevel;
    static float speed, time_before_next_note;
    static GameManager.Key key;

    public Level() { current_level(0); }
    public Level(int level) { current_level(level); }

    public static void current_level(int a_level_number)
    {
        maxLevel = 10;

        level_number = a_level_number;

        switch (level_number)
        {
            case 0:
                //Infinite mode
                break;
            case 1:
                tessitura = 3;
                max_interval = 2;
                speed = 5;
                time_before_next_note = 1.5f;
                total_nb_of_notes = 5;
                break;
            case 2:
                tessitura = 4;
                max_interval = 3;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            case 3:
                tessitura = 5;
                max_interval = 3;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            case 4:
                tessitura = 6;
                max_interval = 4;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            case 5:
                tessitura = 7;
                max_interval = 4;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            case 6:
                tessitura = 8;
                max_interval = 5;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            case 7:
                tessitura = 9;
                max_interval = 6;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            case 8:
                tessitura = 10;
                max_interval = 7;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            case 9:
                tessitura = 11;
                max_interval = 8;
                speed = 5;
                time_before_next_note = 1.25f;
                total_nb_of_notes = 5;
                break;
            default:
                tessitura = 11;
                max_interval = 11;
                speed = 4;
                time_before_next_note = 1f;
                total_nb_of_notes = 5;
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

    public static int LevelMax
    {
        get { return maxLevel; }
        set { maxLevel = value; }
    }
}
