using UnityEngine;
using System.Collections;
using System.Text;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class ViewLevel : MonoBehaviour
{
    public GameObject levelText1, levelText2, levelText3;
    public int level;
    void Start()
    {
        levelText1.SetActive(true);
        levelText2.SetActive(true);
        levelText3.SetActive(true);
        Checked();
    }
    public void Checked()
    {
        LevelHandler levelHandler = new LevelHandler();
        levelHandler.checkLevel(level,levelText1, levelText2, levelText3);
    }
}
