using BounceHitman.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObjectList : SingletonMonoBehaviour<MissionObjectList>
{
    [SerializeField]
    private List<MissionObject> missionObjects = new List<MissionObject>();

    [SerializeField]
    private int totalStars = 0;

    public int TotalStars { get => totalStars; set => totalStars = value; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
    }

    public void LoadData()
    {
        if (DataManager.Instance == null || missionObjects == null)
            return;

        DataManager.Instance.Load();

        TotalStars = DataManager.Instance.TotalStars;

        foreach (MissionObject missionObject in DataManager.Instance.MissionObjects)
        {
            FindBySceneName(missionObject.sceneName).isUnlock = true;
        }
    }

    public void SaveData()
    {
        if (DataManager.Instance == null || missionObjects == null)
            return;


    }

    public MissionObject FindBySceneName(string sceneName)
    {
        foreach (MissionObject missionObject in missionObjects)
        {
            if (missionObject.sceneName == sceneName)
                return missionObject;
        }
        return null;
    }

}
