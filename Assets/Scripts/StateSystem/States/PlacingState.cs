using BounceHitman.Controllers;
using BounceHitman.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingState : IState
{
    private readonly GameManager gameManager;
    private readonly IInputManager inputManager;

    private readonly PlayerController playerController;

    public PlacingState(GameManager gameManager, IInputManager inputManager)
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
        playerController.PlacingProcess(touchPosition);
    }

    private void DraggingHandler(Vector3 touchPosition)
    {
        playerController.PlacingProcess(touchPosition);
    }

    private void ReleaseDragHandler(Vector3 touchPosition)
    {
        playerController.PlacingProcess(touchPosition);
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
        inputManager.onDragging += DraggingHandler;
        inputManager.onReleaseDrag += ReleaseDragHandler;
    }
}
