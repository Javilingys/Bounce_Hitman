using BounceHitman.InputSystem;
using BounceHitman.Player;
using System;
using UnityEngine;

namespace BounceHitman.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private RotatorByDrag rotatorByDrag = null;
        private AimRenderer aimRenderer = null;

        #region Unity Functions
        private void Awake()
        {
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
        #endregion

        #region Private Functions
        #endregion
    }
}