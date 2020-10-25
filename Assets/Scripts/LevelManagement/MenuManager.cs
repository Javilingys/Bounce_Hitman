using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        public Menu mainMenuPrefab;
        public Menu settingsMenuPrefab;
       // public Menu creditsScreenPrefab;

        [SerializeField]
        private Transform menuParent;

        private void Awake()
        {
            InitializeMenus();
        }

        private void InitializeMenus()
        {
            if (menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                menuParent = menuParentObject.transform;
            }

            Menu[] menuPrefabs = { mainMenuPrefab, settingsMenuPrefab };

            foreach (Menu prefab in menuPrefabs)
            {
                if (prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, menuParent);
                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        // open main menu
                    }
                }
            }
        }
    }
}