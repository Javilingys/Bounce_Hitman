using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    public event Action onBulletCollisionEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(Tags.BULLET_TAG))
        {
            onBulletCollisionEvent?.Invoke();
        }
    }
}
