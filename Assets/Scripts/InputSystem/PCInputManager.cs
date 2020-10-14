using System;
using UnityEngine;

namespace BounceHitman.InputSystem
{
    public class PCInputManager : MonoBehaviour, IInputManager
    {
        public event Action<Vector3> onStartDrag;
        public event Action<Vector3> onDragging;
        public event Action<Vector3> onReleaseDrag;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

            }    
        }

    }
}