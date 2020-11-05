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

    bool isStartDragging = false;

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
        Debug.Log("PLACING");
        InputListenersRegister();
        gameManager.IsPlacingMode = true;
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
        isStartDragging = true;
    }

    private void DraggingHandler(Vector3 touchPosition)
    {
        if (isStartDragging)
        {
            playerController.PlacingProcess(touchPosition);
        }
    }

    private void ReleaseDragHandler(Vector3 touchPosition)
    {
        if (isStartDragging)
        {
            playerController.PlacingProcess(touchPosition);
            gameManager.IsPlacingMode = false;
            isStartDragging = false;
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
