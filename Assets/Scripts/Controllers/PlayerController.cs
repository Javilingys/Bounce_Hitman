using BounceHitman.InputSystem;
using BounceHitman.Player;
using System;
using UnityEngine;

namespace BounceHitman.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private MoveByDrag moveByDrag = null;
        private RotatorByDrag rotatorByDrag = null;
        private AimRenderer aimRenderer = null;

        #region Unity Functions
        private void Awake()
        {
            moveByDrag = GetComponent<MoveByDrag>();
            rotatorByDrag = GetComponent<RotatorByDrag>();
            aimRenderer = GetComponent<AimRenderer>();
        }
        #endregion

        #region Public Functions
        public void AimingProcess(Vector3 touchPosition)
        {
            rotatorByDrag.Rotate(touchPosition);
            aimRenderer.SetLine();
        }

        public void PlacingProcess(Vector3 touchPosition)
        {
            moveByDrag.Move(touchPosition);
        }
        #endregion

        #region Private Functions
        #endregion
    }
}