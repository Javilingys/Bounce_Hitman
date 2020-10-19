using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IState
{
    private readonly GameManager gameManager = null;
    public ShootingState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void OnEnter()
    {
        gameManager.PlayerController.InstantiateBullet();
        gameManager.CameraManager.TargetUpdate(gameManager.PlayerController.GetBullet());
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
