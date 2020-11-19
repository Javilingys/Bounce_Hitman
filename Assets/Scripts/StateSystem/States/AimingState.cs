using BounceHitman.Controllers;
using BounceHitman.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingState : IState
{
    private readonly GameManager gameManager;
    private readonly IInputManager inputManager;

    private readonly PlayerController playerController;

    bool isStartDragging = false;

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
        if (gameManager.TutorialLevel)
        {
            TutorialCanvas.Instance.ShowAimInfoPanel();
        }
        AudioManager.Instance.PlayReloadSFX();
        InputListenersRegister();
    }

    public void OnExit()
    {
        InputListenersUnregister();
    }

    public void Tick()
    {
    }

    private void StartDragHandler(Vector3 touchPosition)
    {
        if (gameManager.TutorialLevel)
        {
            TutorialCanvas.Instance.HideAllPanels();
        }
        playerController.AimingProcess(touchPosition);
        isStartDragging = true;
    }

    private void DraggingHandler(Vector3 touchPosition)
    {
        if (isStartDragging)
        {
            playerController.AimingProcess(touchPosition);
        }
    }

    private void ReleaseDragHandler(Vector3 touchPosition)
    {
        if (isStartDragging)
        {
            playerController.AimingProcess(touchPosition);
            gameManager.IsShotingMode = true;
            gameManager.PlayerController.ClearAim();
        }
    }

    private void InputListenersRegister()
    {
        inputManager.onStartDrag += StartDragHandler;
        inputManager.onDragging += DraggingHandler;
        inputManager.onReleaseDrag += ReleaseDragHandler;
    }

    private void InputListenersUnregister()
    {
        inputManager.onStartDrag -= StartDragHandler;
        inputManager.onDragging -= DraggingHandler;
        inputManager.onReleaseDrag -= ReleaseDragHandler;
    }
}
