using BounceHitman.Controllers;
using BounceHitman.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingState : IState
{
    private readonly GameManager gameManager;
    private readonly PlayerController playerController = null;
    private readonly IInputManager inputManager;

    public AimingState(GameManager gameManager, IInputManager inputManager)
    {
        this.gameManager = gameManager;
        this.inputManager = inputManager;
        if (gameManager)
        {
            playerController = gameManager.PlayerController;
        }
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void Tick()
    {
    }
}
