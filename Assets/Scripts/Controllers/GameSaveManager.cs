using BounceHitman.Misc;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSaveManager : SingletonMonoBehaviour<GameSaveManager>
{
    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(GetSaveDirectoryPath("game_save"));
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(GetSaveDirectoryPath("game_save"));
        }
    }

    private string GetSaveDirectoryPath(string saveDirectory)
    {
        return Path.Combine(Application.persistentDataPath, saveDirectory);
    }

    private string GetPathFromSaveFile(string saveFile)
    {
        return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
    }
}
