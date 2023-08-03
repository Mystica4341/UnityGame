using UnityEngine;
using System.Collections;

class Player
{
    private string uid;
    public string UID
    {
        get { return uid; }
        set { this.uid = value; }
    }
    private int fruitNums;
    public int FruitNums
    {
        get { return fruitNums; } set { this.fruitNums = value; }
    }
    public Player(string uid, int fruitNums)
    {
        this.UID = uid;
        this.FruitNums= fruitNums;
    }
}
