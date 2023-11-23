using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.SceneManagement;
public class signWin : MonoBehaviour
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

        string filepath = Application.dataPath + "/StreamingAssets/" + DatabaseName;
        //open db connection
        conn = "URI=file:" + filepath;
        Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();
    }
   public void signInButton()
    {
        signInf(username.text, password.text);
    }
   public void signInf(string usr, string pass)
    {
        SqliteConnection dbconn = new SqliteConnection(conn);

        dbconn.Open();
        SqliteCommand cmd = new SqliteCommand("SELECT * FROM Login WHERE username = @usern AND password = @passw", dbconn);
        cmd.Parameters.AddWithValue("usern", usr);
        cmd.Parameters.AddWithValue("passw", pass);
        // cmd.ExecuteNonQuery();
        SqliteDataAdapter sda = new SqliteDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
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
