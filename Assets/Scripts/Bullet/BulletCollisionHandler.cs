using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletCollisionHandler : MonoBehaviour
{
    public static event Action<Vector2> onBulletOnWallCollision;
    public static event Action<Vector2> onBulletOnEnemyCollision;
    public static event Action<Transform> onBulletOnEnemyCollisionForCamera;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.WALL_TAG))
        {
            Vector2 dirNormal = collision.contacts[0].normal;
            Vector3 dir = Vector3.Reflect(transform.right, dirNormal);
            transform.right = dir;

            onBulletOnWallCollision?.Invoke(collision.contacts[0].point);
        }
        else if(collision.gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            onBulletOnEnemyCollision?.Invoke(collision.contacts[0].point);
            onBulletOnEnemyCollisionForCamera?.Invoke(collision.gameObject.transform);
        }
    }

}
