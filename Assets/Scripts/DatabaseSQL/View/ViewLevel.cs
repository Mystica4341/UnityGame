using UnityEngine;
using System.Collections;
using System.Text;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class ViewLevel : MonoBehaviour
{
    private Level level;
    public GameObject levelNextText;
    private string db_string = "Data Source = GameObject.db; FailIfMissing = false";
    IDataReader reader;
    void Start()
    {
        Checked();
    }
    public void Checked() {
        using (var connection = new SqliteConnection(db_string))
        {
            var levelHandler = new LevelHandler();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Levels FROM Levels";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int levels = Convert.ToInt32(reader.GetValue(0));
                    levelHandler.checkLevel(levels, levelNextText);
                }
            }
            connection.Close();
        }
    }

}
