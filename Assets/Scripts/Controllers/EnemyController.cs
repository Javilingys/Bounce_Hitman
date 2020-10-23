using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject bloodEffect;

    private EnemyRagdoll enemyRagdoll;
    private EnemyCollisionHandler collisionHandler;
    private EnemyAnimator enemyAnimator;

    #region Unity Methods
    private void Awake()
    {
        enemyRagdoll = GetComponent<EnemyRagdoll>();
        collisionHandler = GetComponent<EnemyCollisionHandler>();
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void OnEnable()
    {
        collisionHandler.onBulletCollisionEvent += BulletCollisionHandle;
        BulletCollisionHandler.onBulletOnEnemyCollision += SpawnBloodEffect;
    }

    private void OnDisable()
    {
        collisionHandler.onBulletCollisionEvent -= BulletCollisionHandle;
        BulletCollisionHandler.onBulletOnEnemyCollision -= SpawnBloodEffect;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void BulletCollisionHandle()
    {
        enemyAnimator.StopEnemyAnimation();
        enemyRagdoll.EnableRagdoll();
    }

    private void SpawnBloodEffect(Vector2 spawnPoint)
    {
        Instantiate(bloodEffect, spawnPoint, Quaternion.identity);
    }
    #endregion
}
