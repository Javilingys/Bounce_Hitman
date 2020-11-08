using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public float masterVoulme;
    public float sfxVolume;
    public float musicVolume;

    public string hashValue;

    public SaveData()
    {
        masterVoulme = default;
        sfxVolume = default;
        musicVolume = default;

        hashValue = String.Empty;
    }
}
