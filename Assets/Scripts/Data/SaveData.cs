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

    public int countToAd;

    public string hashValue;

    public SaveData()
    {
        masterVoulme = default;
        sfxVolume = -5f;
        musicVolume = -15f;

        missionObjects = new List<MissionObject>();
        totalStars = default;

        countToAd = default;

        hashValue = String.Empty;
    }
}
