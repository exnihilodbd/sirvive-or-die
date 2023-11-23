using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.SceneManagement;

public class signin : MonoBehaviour
{
    IDbConnection dbconn;
    IDbCommand dbcmd;
    IDataReader reader;
    string conn;
    public InputField username;
    public InputField password;
    public Text dis;
    //public 
    string DatabaseName = "playerdb.db";
    // Start is called before the first frame update
    void Start()
    {
        //Application database Path android
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/Employers");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/playerdb.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }

        conn = "URI=file:" + filepath;

        Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        string query;
        query = "CREATE TABLE Login ( username varchar(100), password varchar(200))";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);

        }

    }
    public void signInButton()
    {
        signInf(username.text, password.text);
    }
   public void signInf(string usr, string pass)
    {
        SqliteConnection dbconn = new SqliteConnection(conn);
        
            dbconn.Open();
            SqliteCommand cmd = new SqliteCommand("SELECT * FROM Login WHERE username = @usern AND password = @passw",dbconn);
            cmd.Parameters.AddWithValue("usern", usr);
            cmd.Parameters.AddWithValue("passw", pass);
        // cmd.ExecuteNonQuery();
        SqliteDataAdapter sda = new SqliteDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if(dt.Rows.Count > 0)
        {
            dis.text = "loggin successful";
            SceneManager.LoadScene(2);
        }
        else
        {
            dis.text = "error";

        }     
    }
    public void goback()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
