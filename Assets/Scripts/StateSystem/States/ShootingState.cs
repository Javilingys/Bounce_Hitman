using BounceHitman.Bullet;
using UnityEngine;

public class ShootingState : IState
{
    private readonly GameManager gameManager = null;
    public ShootingState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void OnEnter()
    {
        TimeManager.Instance.DoSlwomotionWhileShot();
        gameManager.PlayerController.InstantiateBullet();
        gameManager.CameraManager.TargetUpdate(gameManager.PlayerController.GetBullet());
        BulletCollisionHandler.onBulletOnEnemyCollisionForCamera += EnemyHit;
    }

    public void OnExit()
    {
        BulletCollisionHandler.onBulletOnEnemyCollisionForCamera -= EnemyHit;
    }

    public void Tick()
    {

    }

    private void EnemyHit(Transform enemyTransform)
    {
        gameManager.CameraManager.TargetUpdate(enemyTransform);
        TimeManager.Instance.DoSlwomotionWhileHit();
    }
}
