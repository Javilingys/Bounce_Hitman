using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        private float timeScaleBeforPause = 0f;
        public float TimeScaleBeforePause
        {
            get => timeScaleBeforPause;
            set => timeScaleBeforPause = value;
        }

        public void OnResumePressed()
        {
            Time.timeScale = timeScaleBeforPause;
            base.OnBackPressed();
            GameManager.Instance.IsPause = false;
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1f;
            GameManager.Instance.PrepareToReloadLevel();
            LevelLoader.ReloadLevel();
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1f;
            GameManager.Instance.PrepareToReloadLevel();
            MenuManager.Instance.CloseAllMenus();
            LevelLoader.LoadMainMenuLevel();
        }
    }
}