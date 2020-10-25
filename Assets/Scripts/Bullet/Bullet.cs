using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    private float speed = 0f;
    [SerializeField]
    private GameObject sparkleParticle;
    [SerializeField]
    private int maxBounceCount = 0;

    private int currentBounceCoune;
    private Rigidbody2D rigidbody2D = null;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        BulletCollisionHandler.onBulletOnWallCollision += SpawnSparkle;
        BulletCollisionHandler.onBulletOnEnemyCollision += ImmediateDestroyed;
    }

    void Start()
    {
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnDisable()
    {
        BulletCollisionHandler.onBulletOnWallCollision -= SpawnSparkle;
        BulletCollisionHandler.onBulletOnEnemyCollision -= ImmediateDestroyed;
    }

    private void SpawnSparkle(Vector2 spawnPoint)
    {
        Instantiate(sparkleParticle, spawnPoint, Quaternion.identity);
        DestroyProcess();
    }

    private void DestroyProcess()
    {
        currentBounceCoune++;

        if (currentBounceCoune >= maxBounceCount)
        {
            Destroy(this.gameObject);
        }
    }

    private void ImmediateDestroyed(Vector2 uselesPoint)
    {
        Invoke(nameof(InnerDestroy), 0.065f);

    }

    void InnerDestroy()
    {
        Destroy(this.gameObject);
    }
}
