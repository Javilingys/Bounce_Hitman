using BounceHitman.InputSystem;
using BounceHitman.Player;
using System;
using UnityEngine;

namespace BounceHitman.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private IInputManager inputManager;
        private RotatorByDrag rotatorByDrag = null;
        private AimRenderer aimRenderer = null;

        #region Unity Functions
        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                inputManager = gameObject.AddComponent<MobileInputManager>();
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                inputManager = gameObject.AddComponent<PCInputManager>();
            }

            rotatorByDrag = GetComponent<RotatorByDrag>();
            aimRenderer = GetComponent<AimRenderer>();
        }

        private void OnEnable()
        {
            InputListenersRegister();
        }

        private void OnDisable()
        {
            InputListenersUnregister();
        }
        #endregion

        #region Public Functions
        #endregion

        #region Private Functions
        private void StartDragHandler(Vector3 touchPosition)
        {
            rotatorByDrag.Rotate(touchPosition);
            aimRenderer.SetLine();
        }

        private void DraggingHandler(Vector3 touchPosition)
        {
            rotatorByDrag.Rotate(touchPosition);
            aimRenderer.SetLine();
        }

        private void ReleaseDragHandler(Vector3 touchPosition)
        {
            rotatorByDrag.Rotate(touchPosition);
            aimRenderer.ClearLine();
        }

        private void RotationProcess(Vector3 targetPosition)
        {
            rotatorByDrag.Rotate(targetPosition);
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
        #endregion
    }
}