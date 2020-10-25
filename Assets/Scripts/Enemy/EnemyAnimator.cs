using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator animator;

        #region Unity Methods
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        #endregion

        #region Public Methods
        public void StopEnemyAnimation()
        {
            animator.enabled = false;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}