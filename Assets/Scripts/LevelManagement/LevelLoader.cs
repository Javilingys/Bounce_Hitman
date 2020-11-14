using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BounceHitman.LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        private static int mainMenuIndex = 1;

        public static void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LevelLoader LoadLevel Error: Invalid scene specifieed!");
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == mainMenuIndex)
                {
                    MainMenu.Open();
                }

                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }
        }

        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }

        public static void LoadNextLevel()
        {
            LoadLevel(GetNextLevelIndex());
        }

        public static int GetNextLevelIndex()
        {
            int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1)
               % SceneManager.sceneCountInBuildSettings;
            nextSceneIndex = Mathf.Clamp(nextSceneIndex, mainMenuIndex, nextSceneIndex);

            return nextSceneIndex;
        }

        public static string GetNextLevelName()
        {

            return GetSceneNameByBuildIndex(GetNextLevelIndex());
        }

        public static string GetSceneNameByBuildIndex(int buildIndex)
        {
            return GetSceneNameFromScenePath(SceneUtility.GetScenePathByBuildIndex(buildIndex));
        }

        private static string GetSceneNameFromScenePath(string scenePath)
        {
            // Unity's asset paths always use '/' as a path separator
            var sceneNameStart = scenePath.LastIndexOf("/", StringComparison.Ordinal) + 1;
            var sceneNameEnd = scenePath.LastIndexOf(".", StringComparison.Ordinal);
            var sceneNameLength = sceneNameEnd - sceneNameStart;
            return scenePath.Substring(sceneNameStart, sceneNameLength);
        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(mainMenuIndex);
        }
    }
}