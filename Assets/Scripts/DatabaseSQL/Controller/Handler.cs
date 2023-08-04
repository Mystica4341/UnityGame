using UnityEngine.UI;
using UnityEngine;
using System.Data;
using System.Collections;
using Mono.Data.Sqlite;

public class Handler : MonoBehaviour
{
    private string db_string = "Data Source = GameObject.db; FailIfMissing = false";
    void Start()
    {
        createDB();
        insertDataPlayer("Player01025", 0);
        insertDataLevels(1, "Uncomplete");
        insertDataLevels(2, "Uncomplete");
        insertDataLevels(3, "Uncomplete");
        insertDataLevels(4, "Uncomplete");
        insertDataLevels(5, "Uncomplete");
    }
    public void createDB()
    {
        using (var connection = new SqliteConnection(db_string))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Player (UID char(20) UNIQUE, FruitNums int);";
                command.ExecuteNonQuery();
            };
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Levels (Level int UNIQUE, status varchar(10));";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public void insertDataPlayer(string uid, int fruitNums)
    {
        using (var connection = new SqliteConnection(db_string))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Player (UID, FruitNums) VALUES ('" + uid + "'," + fruitNums + ")";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public void insertDataLevels(int level, string status)
    {
        using (var connection = new SqliteConnection(db_string))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Levels (Level, status) VALUES (" + level + ",'" + status + "')";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
