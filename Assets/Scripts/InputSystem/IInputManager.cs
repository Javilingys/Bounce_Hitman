using System;
using UnityEngine;

namespace BounceHitman.InputSystem
{
    public interface IInputManager
    {
        event Action<Vector3> onStartDrag;
        event Action<Vector3> onDragging;
        event Action<Vector3> onReleaseDrag;
    }
}