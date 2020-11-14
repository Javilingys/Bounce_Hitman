using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MissionObject
{
    public string sceneName;
    public int score;
    public int scoreForUnlock;
    public int bounceCount;
    public int countFor3Star;
    public int countFor2Star;
    public bool isUnlock;

    public MissionObject()
    {
        sceneName = default;
        score = default;
        bounceCount = default;
        countFor3Star = default;
        countFor2Star = default;
        isUnlock = default;
    }
}
