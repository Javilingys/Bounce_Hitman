using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.Enemy
{
    public class EnemyRagdoll : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] bodyParts;

        #region Public Methods
        public void EnableRagdoll()
        {
            GetComponent<Collider2D>().enabled = false;

            foreach (GameObject bodyPart in bodyParts)
            {
                bodyPart.GetComponent<Rigidbody2D>().isKinematic = false;
                bodyPart.GetComponent<Collider2D>().enabled = true;
            }
        }

        public void DisableRagdoll()
        {
            GetComponent<Collider2D>().enabled = true;
            foreach (GameObject bodyPart in bodyParts)
            {
                bodyPart.GetComponent<Rigidbody2D>().isKinematic = true;
                bodyPart.GetComponent<Collider2D>().enabled = false;
            }
        }
        #endregion

        #region Private Methods
        #endregion
    }
}