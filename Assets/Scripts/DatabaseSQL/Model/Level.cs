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
    
    private int star;
    public int Star
    {
        get { return star; }
        set { star = value; }
    }

    public Level(int level, string status, int star)
    {
        this.NumsLevel = level;
        this.Status = status;
        this.Star = star;
    }
}
