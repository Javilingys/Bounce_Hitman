using BounceHitman.Controllers;
using BounceHitman.InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    [Range(0f, 1f)]
    private float slowMotionTimeScale = 0f;
    public float SlowMotionTimeScale
    {
        get => slowMotionTimeScale;
        private set { slowMotionTimeScale = value; }
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

        stateMachine = new StateMachine();

        // States initializaing
        var placing = new PlacingState(this, inputManager);
        var aiming = new AimingState(this, inputManager);
        var shoting = new ShootingState(this);

        // Transitions initializing
        At(placing, aiming, IsPlacing());
        At(aiming, shoting, IsShooting());

        // Set State
        stateMachine.SetState(placing);

        // Local Functions
        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        // Loacl Conditions
        Func<bool> IsPlacing() => () => !IsPlacingMode;
        Func<bool> IsShooting() => () => IsShotingMode;
    }

    private void Update()
    {
        stateMachine.Tick();
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
