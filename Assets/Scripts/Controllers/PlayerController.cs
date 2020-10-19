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
        private PlayerShooter playerShooter = null;

        #region Unity Functions
        private void Awake()
        {
            moveByDrag = GetComponent<MoveByDrag>();
            rotatorByDrag = GetComponent<RotatorByDrag>();
            aimRenderer = GetComponent<AimRenderer>();
            playerShooter = GetComponent<PlayerShooter>();
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

        public void ClearAim()
        {
            aimRenderer.ClearLine();
        }

        public void InstantiateBullet()
        {
            playerShooter.InstantiateBullet();
        }
        #endregion

        #region Private Functions
        #endregion
    }
}