using BounceHitman.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.Enemy
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        public event Action onBulletCollisionEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tags.BULLET_TAG))
            {
                AudioManager.Instance.PlayEnemyScreamSFX();
                onBulletCollisionEvent?.Invoke();
            }
        }
    }
}