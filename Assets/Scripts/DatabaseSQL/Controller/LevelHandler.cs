using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private string db_string = "Data Source = GameObject.db; FailIfMissing = false";
    IDataReader reader;
    public void checkLevel(int level, GameObject levelText)
    {
        using (var connection = new SqliteConnection(db_string))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                int temp = level - 1;
                command.CommandText = "SELECT status FROM Levels WHERE Levels = '" + temp + "'";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) == "Uncomplete")
                        levelText.SetActive(false);
                    else if (reader.GetString(0) == "Complete")
                        levelText.SetActive(true);
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
