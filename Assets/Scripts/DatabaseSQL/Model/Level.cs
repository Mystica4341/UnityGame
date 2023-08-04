using UnityEngine;
using System.Collections;

class Level
{
    private int numsLevel;
    public int NumsLevel
    {
        get { return numsLevel; }
        set { numsLevel = value; }
    }
    private string status;
    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    public Level()
    {

    }

    public Level(int level, string status)
    {
        this.NumsLevel = level;
        this.Status = status;
    }
}
