using System;
using UnityEngine;

namespace BounceHitman.Player
{
    public class RotatorByDrag : MonoBehaviour
    {
        [SerializeField]
        private Transform objectForRotation = null;

        private bool isRight = true;

        public event Action onSideChange;

        #region Unity Functions
        #endregion

        #region Public Functions
        public void Rotate(Vector3 targetPosition, bool isOpositeDirection = true)
        {
            if (!objectForRotation) return;

            Vector3 dir = isOpositeDirection ? objectForRotation.position - targetPosition : targetPosition - objectForRotation.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            objectForRotation.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        #endregion

        #region Private Functions
        private void CheckRotationForChangeSide()
        {
            Debug.Log(objectForRotation.eulerAngles.z);
            if (isRight)
            {
                if (Mathf.Abs(objectForRotation.eulerAngles.z) > 90f)
                {
                    objectForRotation.localScale = new Vector3(-objectForRotation.transform.localScale.x,
                                                                objectForRotation.transform.localScale.y,
                                                                objectForRotation.transform.localScale.z);
                    isRight = false;

                }
            }
            else if (!isRight)
            {
                if (Mathf.Abs(objectForRotation.eulerAngles.z) < 90f)
                {
                    objectForRotation.localScale = new Vector3(-objectForRotation.transform.localScale.x,
                                                                objectForRotation.transform.localScale.y,
                                                                objectForRotation.transform.localScale.z);
                    isRight = true;
                }
            } 
        }
        #endregion
    }
}