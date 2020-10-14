using System;
using UnityEngine;

namespace BounceHitman.InputSystem
{
    public class MobileInputManager : MonoBehaviour, IInputManager
    {
        private Touch touch = default;

        public event Action<Vector3> onStartDrag;
        public event Action<Vector3> onDragging;
        public event Action<Vector3> onReleaseDrag;

        #region Unity Functions
        private void Update()
        {
            TouchDetect();
        }
        #endregion

        #region Public Functions
        #endregion

        #region Private Functions
        private void TouchDetect()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    CallActionOnPointer((position) => onStartDrag?.Invoke(position), touch);
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    CallActionOnPointer((position) => onDragging?.Invoke(position), touch);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    CallActionOnPointer((position) => onReleaseDrag?.Invoke(position), touch);
                }
            }
        }

        private void CallActionOnPointer(Action<Vector3> action, Touch currentTouch)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(currentTouch.position);
            position.z = 0f;
            action?.Invoke(position);
        }
        #endregion
    }
}