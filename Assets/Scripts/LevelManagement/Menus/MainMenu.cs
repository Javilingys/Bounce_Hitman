using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField]
        private float playDelay = 0.5f;

        [SerializeField]
        private TransitionFader startTransitionPrefab;

        public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(startTransitionPrefab);
            LevelLoader.LoadNextLevel();
            yield return new WaitForSeconds(playDelay);
            GameMenu.Open();
        }

        public void OnSettingsPressed()
        {
            SettingsMenu.Open();
        }

        public void OnCreditsPressed()
        {

        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}