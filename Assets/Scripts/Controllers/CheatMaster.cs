using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BounceHitman.Misc;

public class CheatMaster : SingletonMonoBehaviour<CheatMaster>
{
    private bool isCheatActive = false;
    public bool IsCheatActive { get => isCheatActive; private set { isCheatActive = value; } }

    [SerializeField]
    [Tooltip("How many rounds chet will active")]
    private int countOfRounds = 0;

    private int currentCountOfRounds = 0;

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
            currentCountOfRounds = countOfRounds;
        }
    }

    public void CheactActivated()
    {
        IsCheatActive = true;
    }

    public void CheactDeactivated()
    {
        IsCheatActive = false;
        currentCountOfRounds = countOfRounds;
    }

    public void Tick()
    {
        if (!IsCheatActive) return;

        currentCountOfRounds--;
        if (currentCountOfRounds <= 0)
        {
            CheactDeactivated();
        }
    }
}
