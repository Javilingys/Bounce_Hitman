using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSaver
{
    private static readonly string filename = "saveData1.sav";

    public static string GetSaveFilename()
    {
        return Path.Combine(Application.persistentDataPath, filename);
    }

    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        string saveFileName = GetSaveFilename();

        using (FileStream fileStream = new FileStream(saveFileName, FileMode.Create))
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    public bool Load(SaveData data)
    {
        string loadFilename = GetSaveFilename();
        if (File.Exists(loadFilename))
        {
            using (StreamReader reader = new StreamReader(loadFilename))
            {
                string json = reader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(json, data);
            }
            return true;
        }
        return false;
    }

    public void Delete()
    {
        File.Delete(GetSaveFilename());
    }
}
