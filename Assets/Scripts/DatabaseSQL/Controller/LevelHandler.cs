using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private string db_string = "Data Source = GameObject.db; FailIfMissing = false";
    IDataReader reader;
    public void checkLevel(int level, GameObject levelText1, GameObject levelText2, GameObject levelText3)
    {
        using (var connection = new SqliteConnection(db_string))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                if (level == 1)
                {
                    command.CommandText = "SELECT status FROM Levels WHERE Level = " + level;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == "Uncomplete")
                        {
                            levelText1.SetActive(false);
                            levelText2.SetActive(false);
                            levelText3.SetActive(false);
                        }
                    }
                }
                if (level == 2)
                {
                    command.CommandText = "SELECT status FROM Levels WHERE Level = " + level;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == "Uncomplete")
                        {
                            levelText2.SetActive(false);
                            levelText3.SetActive(false);
                        }
                    }
                }
                if (level == 3)
                {
                    command.CommandText = "SELECT status FROM Levels WHERE Level = " + level;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == "Uncomplete")
                        {
                            levelText3.SetActive(false);
                        }
                    }
                }
            }
            connection.Close();
        }
    }
    public int allLevel()
    {
        int result = 0;
        using (var connection = new SqliteConnection(db_string))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM Levels";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }
            connection.Close();
        }
        return result;
    }
}
