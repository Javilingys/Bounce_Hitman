using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private SaveData saveData;
    private JsonSaver jsonSaver;

    public float MasterVolume
    {
        get => saveData.masterVoulme;
        set => saveData.masterVoulme = value;
    }

    public float SfxVolume
    {
        get => saveData.sfxVolume;
        set => saveData.sfxVolume = value;
    }

    public float MusicVolume
    {
        get => saveData.musicVolume;
        set => saveData.musicVolume = value;
    }

    private void Awake()
    {
        saveData = new SaveData();
        jsonSaver = new JsonSaver();
    }

    public void Save()
    {
        jsonSaver.Save(saveData);
    }

    public void Load()
    {
        jsonSaver.Load(saveData);
    }
}
