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

    private IInputManager inputManager;

    private StateMachine stateMachine = null;

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

        var placeing = new PlacingState();
        var aiming = new AimingState(this, inputManager);

        stateMachine.SetState(aiming);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
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
