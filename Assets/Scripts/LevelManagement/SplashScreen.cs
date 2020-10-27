using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.LevelManagement
{
    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField]
        private ScreenFader screenFader;

        [SerializeField]
        private float delay = 1f;

        private void Awake()
        {
            screenFader = GetComponent<ScreenFader>();
        }

        private void Start()
        {
            screenFader.FadeOn();
        }

        public void FadeAndLoad()
        {
            StartCoroutine(FadeAndLoadRoutine());
        }

        private IEnumerator FadeAndLoadRoutine()
        {
            yield return new WaitForSeconds(delay);
            screenFader.FadeOff();
            LevelLoader.LoadMainMenuLevel();

            //wait for fade
            yield return new WaitForSeconds(screenFader.FadeOnDuration);

            Destroy(gameObject);

            // remove the splash sceen object
        }
    }
}