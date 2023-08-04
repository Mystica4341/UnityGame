using System.Data;
using System.Collections;
using Mono.Data.Sqlite;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
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
            int numsFruit = findFruit();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                numsFruit += fruit;
                command.CommandText = "UPDATE player SET fruitnums = "+numsFruit+" WHERE uid = 'Player01025'";
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }
    public int findFruit()
    {
        int numsFruit = 0;
        using (var connection = new SqliteConnection(db_String))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Fruit From Player WHERE uid = 'Player01025'";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numsFruit = reader.GetInt32(0);
                }
            }
            connection.Close();
        }
        return numsFruit;
    }
}
