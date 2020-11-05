using BounceHitman.Controllers;
using BounceHitman.InputSystem;
using BounceHitman.LevelManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton defintion
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    public static event Action<int> onBountCountUpdate;

    [SerializeField]
    private PlayerController playerController;
    public PlayerController PlayerController
    {
        get => playerController;
        private set => playerController = value;
    }

    [SerializeField]
    private CameraManager cameraManager;
    public CameraManager CameraManager
    {
        get => cameraManager;
        private set => cameraManager = value;
    }

    private IInputManager inputManager;

    private StateMachine stateMachine = null;

    private bool isPlacingMode = true;
    public bool IsPlacingMode
    {
        get => isPlacingMode;
        set => isPlacingMode = value;
    }

    private bool isShotingMode = false;
    public bool IsShotingMode
    {
        get => isShotingMode;
        set => isShotingMode = value;
    }

    private bool isPause = false;
    public bool IsPause
    {
        get => isPause;
        set => isPause = value;
    }

    private int maxBounceCount = 0;
    public int MaxBounceCount
    {
        get => maxBounceCount;
    }

    private int currentBounceCount = 0;
    public int CurrentBounceCount
    {
        get => currentBounceCount;
    }

    #region Unity Methods
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            inputManager = gameObject.AddComponent<MobileInputManager>();
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            inputManager = gameObject.AddComponent<PCInputManager>();
        }
        SetMaxBounceCount(Database.GetLevelItemById(SceneManager.GetActiveScene().name));


        stateMachine = new StateMachine();

        // States initializaing
        var placing = new PlacingState(this, inputManager);
        var aiming = new AimingState(this, inputManager);
        var shoting = new ShootingState(this);
        var pausing = new PauseState();

        // Transitions initializing
        At(placing, aiming, IsPlacing());
        At(aiming, shoting, IsShooting());

        At(placing, pausing, IsPasuePlacingTrue());
        At(pausing, placing, IsPasuePlacingFalse());

        At(aiming, pausing, IsPasueAimingTrue());
        At(pausing, aiming, IsPasueAimingFalse());

        // Set State
        stateMachine.SetState(placing);

        // Local Functions
        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        // Loacl Conditions
        Func<bool> IsPlacing() => () => !IsPlacingMode;
        Func<bool> IsShooting() => () => IsShotingMode;
        Func<bool> IsPasuePlacingTrue() => () => IsPlacingAndPauseTrue();
        Func<bool> IsPasuePlacingFalse() => () => IsPlacingAndPauseFalse();
        Func<bool> IsPasueAimingTrue() => () => IsAimingAndPauseTrue();
        Func<bool> IsPasueAimingFalse() => () => IsAimingAndPauseFalse();
    }

    private void OnEnable()
    {
        WinScreenMenu.onFadeInCompleted += LevelEnded;
    }

    private void Update()
    {
        stateMachine.Tick();
    }

    private void OnDisable()
    {
        WinScreenMenu.onFadeInCompleted -= LevelEnded;
    }
    #endregion

    #region Public Methods
    public int DecreaseMaxBounce()
    {
        currentBounceCount--;
        if (currentBounceCount < 0) currentBounceCount = 0;
        return currentBounceCount;
    }

    public void PrepareToReloadLevel()
    {
        stateMachine.ExitCurrentState();
    }
    #endregion

    #region Private Methods
    private void SetMaxBounceCount(LevelItem levelItem)
    {
        if (levelItem == null)
        {
            Debug.LogWarning("BULLET levelItem == null");
            return;
        }

        maxBounceCount = levelItem.BounceCount;
        currentBounceCount = maxBounceCount;
        onBountCountUpdate?.Invoke(maxBounceCount);
    }

    private void LevelEnded()
    {
        int scoreFor3Stars = Database.GetLevelItemById(SceneManager.GetActiveScene().name).CountFor3Star;
        int scoreFor2Stars = Database.GetLevelItemById(SceneManager.GetActiveScene().name).CountFor2Star;

        int bestScore = Database.GetLevelItemById(SceneManager.GetActiveScene().name).Score;
        int currentScore = maxBounceCount;

        if (bestScore > currentScore)
        {
            currentScore = bestScore;
        }

        if ((maxBounceCount - currentBounceCount) <= scoreFor3Stars)
        {
            WinScreenMenu.Instance.SetThreeStars();
        }
        else if ((maxBounceCount - currentBounceCount) > scoreFor3Stars &&
            (maxBounceCount - currentBounceCount) <= scoreFor2Stars)
        {
            WinScreenMenu.Instance.SetTwoStars();
        }
        else if ((maxBounceCount - currentBounceCount) > scoreFor2Stars &&
            currentBounceCount > 0)
        {
            WinScreenMenu.Instance.SetOneStar();
        }

    }

    private bool IsPlacingAndPauseTrue()
    {
        return (IsPause && (IsPlacingMode == true));
    }

    private bool IsPlacingAndPauseFalse()
    {
        return (!IsPause && (IsPlacingMode == true));
    }

    private bool IsAimingAndPauseTrue()
    {
        return (IsPause && (IsPlacingMode == false));
    }

    private bool IsAimingAndPauseFalse()
    {
        return (!IsPause && (IsPlacingMode == false));
    }
    #endregion
}
