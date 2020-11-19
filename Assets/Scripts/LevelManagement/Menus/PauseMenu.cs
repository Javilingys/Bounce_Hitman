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
            AudioManager.Instance.PlayClickSFX();
            Time.timeScale = timeScaleBeforPause;
            base.OnBackPressed();
            GameManager.Instance.IsPause = false;
        }

        public void OnRestartPressed()
        {
            DataManager.Instance.IncreaseCountToAd();
            AudioManager.Instance.PlayClickSFX();
            Time.timeScale = 1f;          
            CheatMaster.Instance.Tick();
            GameManager.Instance.PrepareToReloadLevel();
            LevelLoader.ReloadLevel();
            base.OnBackPressed();
        }

        public void OnCheatPressed()
        {
            AudioManager.Instance.PlayClickSFX();
            Time.timeScale = 1f;
            GameManager.Instance.PrepareToReloadLevel();
            LevelLoader.ReloadLevel();
            base.OnBackPressed();
            AdManager.ShowRewardedAdd(CheatMaster.Instance.CheactActivated,
                                    CheatMaster.Instance.CheactDeactivated,
                                    CheatMaster.Instance.CheactDeactivated);
        }

        public void OnMainMenuPressed()
        {
            AudioManager.Instance.PlayClickSFX();
            Time.timeScale = 1f;
            GameManager.Instance.PrepareToReloadLevel();
            MenuManager.Instance.CloseAllMenus();
            LevelLoader.LoadMainMenuLevel();
        }
    }
}