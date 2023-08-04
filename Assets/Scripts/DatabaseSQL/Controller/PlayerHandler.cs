using System.Data;
using System.Collections;
using Mono.Data.Sqlite;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private int collectedFruit = 0;
    IDataReader reader;
    private string db_String = "Data Source = GameObject.db; FailIfMissing = false";
    public void statusComplete(int levels)
    {
        using(var connection = new SqliteConnection(db_String) )
        {
            connection.Open();
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE levels SET status = 'Complete' WHERE Level = "+ levels;
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }
    public void insertFruit(int fruit)
    {
        using (var connection = new SqliteConnection(db_String))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE player SET FruitNums = "+fruit+" WHERE uid = 'Player01025'";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public int findFruit()
    {
        using (var connection = new SqliteConnection(db_String))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT FruitNums From Player WHERE uid = 'Player01025'";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int result = reader.GetInt32(0);
                    return result;
                }
            }
            connection.Close();
        }
        return 0;
    }
}
