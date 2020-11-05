using BounceHitman.Bullet;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BounceHitman.LevelManagement
{
    public class GameMenu : Menu<GameMenu>
    {
        [SerializeField]
        TextMeshProUGUI bounceCountText;

        private int maxBounceCount;

        private void OnEnable()
        {
            InitBounceCountText();
            BulletCollisionHandler.onBulletOnWallCollision += UpdateBounceCountTextByHit;
            GameManager.onBountCountUpdate += UpdateBounceCountText;
        }

        private void OnDisable()
        {
            BulletCollisionHandler.onBulletOnWallCollision -= UpdateBounceCountTextByHit;
            GameManager.onBountCountUpdate -= UpdateBounceCountText;
        }

        public void InitBounceCountText()
        {
            if (GameManager.Instance != null)
            {
                bounceCountText.text = GameManager.Instance.MaxBounceCount.ToString();
            }
        }

        private void UpdateBounceCountTextByHit(Vector2 spawnPoint)
        {
            bounceCountText.text = GameManager.Instance.DecreaseMaxBounce().ToString();
        }

        private void UpdateBounceCountText(int bounceCount)
        {
            bounceCountText.text = bounceCount.ToString();
        }

        public void OnPausedPressed()
        {
            if (MenuManager.Instance != null && PauseMenu.Instance != null)
            {
                GameManager.Instance.IsPause = true;
                PauseMenu.Instance.TimeScaleBeforePause = Time.timeScale;
                Time.timeScale = 0;
                MenuManager.Instance.OpenMenu(PauseMenu.Instance);
            }
        }
    }
}