using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;



public class Cosa 
{
    public float SpawnX { get; set; }
    public float SpawnY { get; set; }
    public string stringX { get; set; }
    public string stringY { get; set; }
    public int Item1 { get; set; }
    public int Item2 { get; set; }
    public int Item3 { get; set; }
    public int Item4 { get; set; }
    public int Item5 { get; set; }
    public int Item6 { get; set; }
    public int Item7 { get; set; }
    public int Item8 { get; set; }
    public int Item9 { get; set; }

}

public class DBManager : MonoBehaviour
{
    private static DBManager _instance;
    public static DBManager Instance => _instance;

    public static int ActualGameId = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<DBManager>();
            DontDestroyOnLoad(_instance);
        }
    }

    //public static IDbConnection dbconn;

    void Start()
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        CreateTable();
    }

    public  static Cosa GetValues(int id)
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        Cosa cosa = null;
        IDbCommand dbcmd = dbconn.CreateCommand();

        string query = $"select SpawnX,SpawnY, Item1,Item2,Item3,Item4,Item5,Item6, Item7, Item8, Item9  from GameData where Id={id}";

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            
            cosa = new Cosa()
            {
                SpawnX = reader.GetFloat(0),
                SpawnY = reader.GetFloat(1),
                Item1 = reader.GetInt32(2),
                Item2 = reader.GetInt32(3),
                Item3 = reader.GetInt32(4),
                Item4 = reader.GetInt32(5),
                Item5 = reader.GetInt32(6),
                Item6 = reader.GetInt32(7),
                Item7 = reader.GetInt32(8),
                Item8 = reader.GetInt32(9),
                Item9 = reader.GetInt32(10)
            };
        }
        return cosa;
    }

    public static void NewGame()
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "INSERT INTO GameData(SpawnX,SpawnY, Item1,Item2,Item3,Item4,Item5,Item6, Item7, Item8, Item9) Values (-3,-1,0,0,0,0,0,0,0,0,0)";
        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public static void CreateTable()
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "CREATE TABLE IF NOT EXISTS 'GameData' ('Id'    INTEGER NOT NULL,'SpawnX' REAL NOT NULL, 'SpawnY'    REAL NOT NULL,'Item1' INTEGER NOT NULL,'Item2' INTEGER NOT NULL,'Item3' INTEGER NOT NULL,'Item4' INTEGER NOT NULL,'Item5' INTEGER NOT NULL,'Item6' INTEGER NOT NULL,'Item7' INTEGER NOT NULL,'Item8' INTEGER NOT NULL,'Item9', PRIMARY KEY('Id' AUTOINCREMENT))"; 

        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public static void SaveData(Cosa cosa)
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        Debug.Log(cosa.SpawnX);
        string query = $"UPDATE GameData set SpawnX = {cosa.stringX}, SpawnY = {cosa.stringY}, Item1 = {cosa.Item1}, Item2 = {cosa.Item2}, Item3 = {cosa.Item3}, Item4 = {cosa.Item4}, Item5 = {cosa.Item5}, Item6 = {cosa.Item6}, Item7 = {cosa.Item7}, Item8 = {cosa.Item8}, Item9 = {cosa.Item9} WHERE Id = {ActualGameId}";


        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }
    

    public static void CloseDB()
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        dbconn.Close();
    }

    public static int TotalCount()
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        int total = 0;
        IDbCommand dbcmd = dbconn.CreateCommand();

        string query = $"select count(*) from GameData";

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            total = reader.GetInt32(0);
        }
        return total;
    }

    public static List<int> GetAllIds()
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        List<int> total = new List<int>();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string query = $"select Id from GameData";

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            total.Add(reader.GetInt32(0));
        }
        return total;
    }

    public static int GetLastId()
    {
        IDbConnection dbconn;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDataBase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        int total = 0;
        IDbCommand dbcmd = dbconn.CreateCommand();

        string query = $"SELECT Id FROM GameData order by Id DESC LIMIT 1;";

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            total=reader.GetInt32(0);
        }
        return total;
    }

   
}
