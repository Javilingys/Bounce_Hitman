using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BounceHitman.LevelManagement
{
    public class WinScreenMenu : Menu<WinScreenMenu>
    {
        public static event Action onFadeInCompleted;

        [SerializeField]
        private TextMeshProUGUI headerText;

        [SerializeField]
        private Sprite lockStarSprite = null;
        [SerializeField]
        private Sprite unlockStarSprite = null;

        [SerializeField]
        private Image[] stars;

        [SerializeField]
        private Button nextButton;

        private void OnEnable()
        {
            LockAllStars();
        }

        public void SetOneStar()
        {
            LockAllStars();
            stars[0].sprite = unlockStarSprite;
        }

        public void SetTwoStars()
        {
            LockAllStars();
            for (int i = 0; i < stars.Length - 1; i++)
            {
                stars[i].sprite = unlockStarSprite;
            }
        }

        public void SetThreeStars()
        {
            LockAllStars();
            foreach (Image image in stars)
            {
                image.sprite = unlockStarSprite;
            }
        }

        public void LockAllStars()
        {
            foreach (Image image in stars)
            {
                image.sprite = lockStarSprite;
            }
        }

        public void SetLoseText()
        {
            headerText.text = "FAIL";
        }

        public void SetWinText()
        {
            headerText.text = "COMPLETE";
        }

        public void StarCalculate()
        {
            onFadeInCompleted?.Invoke();
        }

        public void SetNextButtonEnabled()
        {
            int totalStars = MissionObjectList.Instance.TotalStars;
            MissionObject missionObject = MissionObjectList.Instance.FindBySceneName(LevelLoader.GetNextLevelName());

            if (missionObject == null)
            {
                nextButton.enabled = false;
                return;
            }

            if (totalStars < missionObject.scoreForUnlock)
            {
                nextButton.enabled = false;
                return;
            }

            nextButton.enabled = true;
        }

        private void SaveGame()
        {
            MissionObjectList.Instance.SaveData();
        }

        public void OnNexLevelPressed()
        {
            SaveGame();
            Time.timeScale = 1f;
            GameManager.Instance.PrepareToReloadLevel();
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }

        public void OnRestartPressed()
        {
            SaveGame();
            Time.timeScale = 1f;
            //MenuManager.Instance.CloseAllMenus();
            GameManager.Instance.PrepareToReloadLevel();
            LevelLoader.ReloadLevel();
            base.OnBackPressed();
            //GameMenu.Open();
        }

        public void OnMainMenuPressed()
        {
            SaveGame();
            Time.timeScale = 1f;
            GameManager.Instance.PrepareToReloadLevel();
            MenuManager.Instance.CloseAllMenus();
            LevelLoader.LoadMainMenuLevel();
        }
    }
}