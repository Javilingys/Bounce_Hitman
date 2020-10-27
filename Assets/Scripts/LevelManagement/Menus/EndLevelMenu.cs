using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.LevelManagement
{
    public class EndLevelMenu : Menu<EndLevelMenu>
    {
        public void OnNexLevelPressed()
        {
            Time.timeScale = 1f;
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1f;
            base.OnBackPressed();
            LevelLoader.ReloadLevel();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1f;
            LevelLoader.LoadMainMenuLevel();

            MainMenu.Open();
        }
    }
}