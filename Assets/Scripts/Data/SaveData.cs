using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public float masterVoulme;
    public float sfxVolume;
    public float musicVolume;

    public List<MissionObject> missionObjects;
    public int totalStars;

    public string hashValue;

    public SaveData()
    {
        masterVoulme = default;
        sfxVolume = default;
        musicVolume = default;

        missionObjects = new List<MissionObject>();
        totalStars = default;

        hashValue = String.Empty;
    }
}
