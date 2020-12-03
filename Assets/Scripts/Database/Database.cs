using BounceHitman.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : SingletonMonoBehaviour<Database>
{
    [SerializeField]
    private LevelItemDatabase levels;

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public static LevelItem GetLevelItemById(string ID)
    {
        return Instance.levels.GetLevelItems().FirstOrDefault(i => i.ID == ID);
    }
}
