using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

public class Database
{
    private static readonly string LevelsPath = Application.streamingAssetsPath + "/Levels.db";

    public void CreateDatabase()
    {
        if (!File.Exists(LevelsPath))
        {
            SqliteConnection.CreateFile(LevelsPath);
        }
        SqliteConnection connection = new SqliteConnection("Data Source=" + LevelsPath);
        connection.Open();

        string sql = "create table Levels (score int)";
            
        SqliteCommand command = new SqliteCommand(sql, connection);
        command.ExecuteNonQuery();
            
        sql = "insert into Levels (score) values (0)";
        command = new SqliteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void SaveDataBase()
    {
        
    }

    public void LoadDataBase()
    {
        
    }
}