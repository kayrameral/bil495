using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npgsql;
using System;


public class DataBaseController : MonoBehaviour
{
    public static DataBaseController instance;
    NpgsqlConnection conn;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
     void Start()
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=1234;Database=UnityDB;");
conn.Open();
NpgsqlCommand command = conn.CreateCommand();
for(int i = 0; i < 100; i++){
     string query = "INSERT INTO \"UnityTable\" VALUES ('value" + i       + "')";
     command.CommandText = query;
     command.ExecuteNonQuery();
}
string a = "SELECT * FROM \"UnityTable\"";
command.CommandText = a;
NpgsqlDataReader reader = command.ExecuteReader();
while (reader.Read()){
    print(reader.GetValue(0));
}
conn.Close();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToDB(Entry e)
    {
        if (e != null)
        {
            try {
            string hash = e.hash;
            NpgsqlCommand command = conn.CreateCommand();
            string query = "INSERT INTO \"UnityTable\" VALUES ('" + hash + "', '" + e.location + "', '" + e.time + "', '" + e.magnitude + "');";
            command.CommandText = query;
            command.ExecuteNonQuery();
        }catch (Exception ex)
        {
           //Unique key error
        }
    }
    }
}
