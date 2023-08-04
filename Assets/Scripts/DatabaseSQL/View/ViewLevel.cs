using UnityEngine;
using System.Collections;
using System.Text;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class ViewLevel : MonoBehaviour
{
    public GameObject levelText1, levelText2, levelText3, levelText4;
    public int level;
    private string db_string = "Data Source = GameObject.db; FailIfMissing = false";
    IDataReader reader;
    void Start()
    {
        levelText1.SetActive(true);
        levelText2.SetActive(true);
        levelText3.SetActive(true);
        levelText4.SetActive(true);
        Checked();
    }
    public void Checked()
    {
        LevelHandler levelHandler = new LevelHandler();
        levelHandler.checkLevel(level,levelText1, levelText2, levelText3, levelText4);
    }
}
