using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BounceHitman.LevelManagement
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        [SerializeField]
        private Slider masterVolumeSlider;

        [SerializeField]
        private Slider sfxVolumeSlider;

        [SerializeField]
        private Slider musicVolumeSlider;

        private DataManager dataManager;

        protected override void Awake()
        {
            base.Awake();

            dataManager = FindObjectOfType<DataManager>();

            LoadData();
        }

        private void Start()
        {
            LoadData();
        }

        public void OnMasterVolumeChanged(float volume)
        {
            if (dataManager != null)
            {
                dataManager.MasterVolume = volume;
            }
            //PlayerPrefs.SetFloat("MasterVolume", volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            if (dataManager != null)
            {
                dataManager.SfxVolume = volume;
            }
            //PlayerPrefs.SetFloat("SFXVolume", volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (dataManager != null)
            {
                dataManager.MusicVolume = volume;
            }
            //PlayerPrefs.SetFloat("MusicVolume", volume);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if (dataManager != null)
            {
                dataManager.Save();
            }
            //PlayerPrefs.Save();
        }

        public void LoadData()
        {
            if (dataManager == null || masterVolumeSlider == null || sfxVolumeSlider == null
                || musicVolumeSlider == null) 
                return;

            dataManager.Load();

            masterVolumeSlider.value = dataManager.MasterVolume;
            sfxVolumeSlider.value = dataManager.SfxVolume;
            musicVolumeSlider.value = dataManager.MusicVolume;
            //masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            //sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            //musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}