using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level0", menuName = "Database/Levels/New Level Item")]
public class LevelItem : ScriptableObject
{
    [SerializeField]
    private string id = "";
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int bounceCount = 0;

    [SerializeField]
    private int countFor3Star = 0;
    [SerializeField]
    private int countFor2Star = 0;

    [SerializeField]
    private bool isLock = true;

    public string ID { get => id; }
    public int Score { get => score; set => score = value; }
    public int BounceCount { get => bounceCount; }
    public bool IsLock { get => isLock; set => isLock = value; }

    public int CountFor3Star { get => countFor3Star; }
    public int CountFor2Star { get => countFor2Star; }
}
