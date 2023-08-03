using System.Data;
using System.Collections;
using Mono.Data.Sqlite;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    IDataReader reader;
    private string db_String = "Data Source = GameObject.db; FailIfMissing = false";
    public void Complete (int levels)
    {
        using(var connection = new SqliteConnection(db_String) )
        {
            connection.Open();
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE levels SET status = 'Complete' WHERE levels = '"+levels+"'";
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }
}
