using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSelector : MonoBehaviour
{
    #region INSPECTOR
    [SerializeField]
    protected MissionList missionList;
    #endregion

    #region PROTECTED
    protected int currentIndex = 0;
    #endregion

    public int CurrentIndex => currentIndex;

    public void ClampIndex()
    {
        if (missionList.TotalMissions == 0)
        {
            Debug.LogWarning($"MISSION SELECTOR ClampIndex: missing mission setup!");
            return;
        }

        if (currentIndex >= missionList.TotalMissions)
        {
            currentIndex = 0;
        }

        if (currentIndex < 0)
        {
            currentIndex = missionList.TotalMissions - 1;
        }
    }

    public void SetIndex(int index)
    {
        currentIndex = index;
        ClampIndex();
    }

    public void IncrementIndex()
    {
        SetIndex(currentIndex + 1);
    }

    public void DecrementIndex()
    {
        SetIndex(currentIndex - 1);
    }

    public MissionSpecs GetMission(int index)
    {
        return missionList.GetMission(index);
    }

    public MissionSpecs GetCurrentMission()
    {
        return missionList.GetMission(currentIndex);
    }
}
