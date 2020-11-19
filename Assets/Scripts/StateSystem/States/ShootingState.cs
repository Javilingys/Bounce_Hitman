using BounceHitman.Bullet;
using BounceHitman.LevelManagement;
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
        TimeManager.onExitSlowMotion += OpenWinScreen;

        AudioManager.Instance.PlayBulletLaunchSFX();
    }

    public void OnExit()
    {
        BulletCollisionHandler.onBulletOnEnemyCollisionForCamera -= EnemyHit;
        TimeManager.onExitSlowMotion -= OpenWinScreen;
    }

    public void Tick()
    {

    }

    private void OpenWinScreen()
    {
        WinScreenMenu.Open();
        WinScreenMenu.Instance.SetWinText();
    }

    private void EnemyHit(Transform enemyTransform)
    {
        gameManager.CameraManager.TargetUpdate(enemyTransform);
        TimeManager.Instance.DoSlwomotionWhileHit();
    }
}
