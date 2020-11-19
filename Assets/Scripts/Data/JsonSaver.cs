using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

public class JsonSaver
{
    private static readonly string filename = "saveData1.sav";

    public static string GetSaveFilename()
    {
        return Path.Combine(Application.persistentDataPath, filename);
    }

    public void Save(SaveData data)
    {
        data.hashValue = String.Empty;

        string json = JsonUtility.ToJson(data);

        data.hashValue = GetSHA256(json);
        json = JsonUtility.ToJson(data);

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

                // verify the data using the hash value
                if (CheckData(json))
                {
                    // read the data and overwrite the save data if the hash is valid
                    JsonUtility.FromJsonOverwrite(json, data);
                }
                else
                {
                    data.countToAd = 4;
                    data.masterVoulme = -40f;
                    data.musicVolume = -40f;
                    data.sfxVolume = -40f;
                }
            }
            return true;
        }
        return false;
    }

    private bool CheckData(string json)
    {
        // create a temporary SaveData object to store the data
        SaveData tempSaveData = new SaveData();

        // read the data into the temp SaveData object
        JsonUtility.FromJsonOverwrite(json, tempSaveData);

        // grab the saved hash value and reset
        string oldHash = tempSaveData.hashValue;
        tempSaveData.hashValue = String.Empty;

        // generate a temporary JSON file with the hash reset to empty
        string tempJson = JsonUtility.ToJson(tempSaveData);

        // calculate the hash 
        string newHash = GetSHA256(tempJson);

        // return whether the old and new hash values match
        return (oldHash == newHash);
    }

    // deletes the save file from disk (useful for testing)
    public void Delete()
    {
        File.Delete(GetSaveFilename());
    }


    public string GetGexStringFromHash(byte[] hash)
    {
        // placeholder string
        string hexString = String.Empty;

        // convert each byte to a two-digit hexidecimal number and add to placeholder
        foreach (byte b in hash)
        {
            hexString += b.ToString("x2");
        }

        return hexString;
    }

    // converts a string into a SHA256 hash value
    private string GetSHA256(string text)
    {
        // conver the text into an array of bytes
        byte[] textToBytes = Encoding.UTF8.GetBytes(text);

        // create a temporary SHA256Managed instance
        SHA256Managed mySHA256 = new SHA256Managed();

        // calculate the hash value as an array of bytes
        byte[] hashValue = mySHA256.ComputeHash(textToBytes);

        // return hex string
        return GetGexStringFromHash(hashValue);
    }
}
