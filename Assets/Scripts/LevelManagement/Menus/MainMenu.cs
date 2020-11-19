using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        private void Start()
        {
            if (!AudioManager.Instance.IsBackgroundMusicStarted)
            {
                AudioManager.Instance.PlayMusic();
            }
        }

        //[SerializeField]
        //private float playDelay = 0.5f;

        //[SerializeField]
        //private TransitionFader startTransitionPrefab;

        public void OnPlayPressed()
        {
            AudioManager.Instance.PlayClickSFX();
            LevelSelectMenu.Open();
            //StartCoroutine(OnPlayPressedRoutine());
        }

        //private IEnumerator OnPlayPressedRoutine()
        //{
        //    TransitionFader.PlayTransition(startTransitionPrefab);

        //    float fadeDelay = (startTransitionPrefab != null) ? startTransitionPrefab.Delay + startTransitionPrefab.FadeOnDuration
        //        : 0f;

        //    LevelLoader.LoadNextLevel();
        //    yield return new WaitForSeconds(fadeDelay);
        //    MenuManager.Instance.CloseAllMenus();
        //    GameMenu.Open();
        //}

        public void OnSettingsPressed()
        {
            AudioManager.Instance.PlayClickSFX();
            SettingsMenu.Open();
        }

        public void OnCreditsPressed()
        {
            AudioManager.Instance.PlayClickSFX();
        }

        public override void OnBackPressed()
        {
            AudioManager.Instance.PlayClickSFX();
            Application.Quit();
        }
    }
}