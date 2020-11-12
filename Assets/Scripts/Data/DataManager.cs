using BounceHitman.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBehaviour<DataManager>
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

    public int TotalStars
    {
        get => saveData.totalStars;
        set => saveData.totalStars = value;
    }

    public List<MissionObject> MissionObjects
    {
        get => saveData.missionObjects;
        set => saveData.missionObjects = value;
    }

    public MissionObject FindBySceneName(string sceneName)
    {
        foreach (MissionObject missionObject in MissionObjects)
        {
            if (missionObject.sceneName == sceneName)
                return missionObject;
        }
        return null;
    }

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            saveData = new SaveData();
            jsonSaver = new JsonSaver();
        }
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
