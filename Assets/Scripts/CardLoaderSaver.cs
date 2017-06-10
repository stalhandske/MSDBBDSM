using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class CardLoaderSaver
{

    public static LibraryData LoadLibrary()
    {
        LibraryData libraryData;

        string path = GetPath();

        if (!File.Exists(path))
            return null;

        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            using (StreamReader writer = new StreamReader(fs))
            {
                string fromFile = writer.ReadToEnd();
                //Debug.Log(fromFile);
                libraryData = JsonUtility.FromJson<LibraryData>(fromFile);
            }
        }

        return libraryData;
    }

    public static void SaveLibrary(LibraryData libraryData)
    {
        Directory.CreateDirectory(GetDirectory());

        using (FileStream fs = new FileStream(GetPath(), FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(JsonUtility.ToJson(libraryData,true));
            }
        }
    }

    static string GetPath()
    {
        return  GetDirectory() + "/cards" + ".json";
    }

    static string GetDirectory()
    {
        return Application.persistentDataPath;
    }
}