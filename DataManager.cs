using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataManager : MonoBehaviour
{
    string path;
    public static DataManager instance;
    public PlayerData playerData;

    void Awake()
    {
        path = Application.persistentDataPath + "/" + Application.identifier + ".txt";

        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        CreateFile();
    }

    void CreateFile()
    {
        if (File.Exists(path))
        {
            return;
        }
        else
        {
            FileStream file = new FileStream(path, FileMode.Create);
            //PlayerData data = new PlayerData();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, playerData);
            file.Close();
            Debug.Log("File Created");
        }
    }


    public void Save(PlayerData data)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(path);

        formatter.Serialize(file, data);
        file.Close();
        Debug.Log("Data is Saved");
    }


    public PlayerData Load()
    {
        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            PlayerData data;
            data = (PlayerData)formatter.Deserialize(file);
            file.Close();
            Debug.Log("Data Loaded");
            return data;
        }
        else
        {
            Debug.Log("No Such Files Exist");
            return null;
        }
    }

#if UNITY_EDITOR
    [MenuItem("DataManager/DeleteSaves")]
    public static void DeleteSaves()
    {
        if (File.Exists(Application.persistentDataPath + "/" + Application.identifier + ".txt"))
        {
            File.Delete(Application.persistentDataPath + "/" + Application.identifier + ".txt");
            Debug.Log("File Deleted!");
        }
    }
#endif
}
