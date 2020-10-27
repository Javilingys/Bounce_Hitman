using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.LevelManagement
{
    public class GameMenu : Menu<GameMenu>
    {
        public void OnPausedPressed()
        {
            if (MenuManager.Instance != null && PauseMenu.Instance != null)
            {
                PauseMenu.Instance.TimeScaleBeforePause = Time.timeScale;
                Time.timeScale = 0;
                MenuManager.Instance.OpenMenu(PauseMenu.Instance);
            }
        }
    }
}